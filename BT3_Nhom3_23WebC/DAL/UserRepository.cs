using BT3_Nhom3_23WebC.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace BT3_Nhom3_23WebC.DAL
{
    public class UserRepository
    {
        public readonly string _connectionString;

        // Lấy connection string từ appsettings.json qua DI
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Kết nối không tồn tại trong cấu hình.");
        }

        public UsersModel? Authenticate(string username, string password)
        {
            // Kiểm tra đầu vào tránh lỗi truy vấn
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return null;

            using var conn = new SqlConnection(_connectionString);
            conn.Open();

            // Truy vấn đúng cú pháp SQL, lấy đúng cột
            var cmd = new SqlCommand(
                "SELECT Username, Password, Role FROM Users WHERE Username = @username AND Password = @password",
                conn
            );
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new UsersModel
                {
                    Username = reader["Username"]?.ToString() ?? string.Empty,
                    Password = reader["Password"]?.ToString() ?? string.Empty,
                    Role = reader["Role"] != DBNull.Value ? Convert.ToInt32(reader["Role"]) : 0
                };
            }
            return null;
        }
    }
}
