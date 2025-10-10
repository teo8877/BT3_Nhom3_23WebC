using BT3_Nhom3_23WebC.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
namespace BT3_Nhom3_23WebC.DAL
{
     public class UserRepository
    {
        public readonly string _connectionString;
        //dung DI de lay connection string tu appsettings.json
        public UserRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Ket noi khong ton tai trong cau hinh.");
        }
        public UsersModel Authenticate(string username,string passwork)
        {
            using var conn=new SqlConnection(_connectionString);
            conn.Open();
            var cmd=new SqlCommand("SELECT Username,Passwork,Role FROM Users WHERE Username=@username AND Passwork=@passwork",conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@passwork", passwork); //truyen gia tri cho tham so @username
          
            using var reader=cmd.ExecuteReader();
            if (reader.Read())
            {
               if(reader["Username"] != DBNull.Value && reader["Passwork"] != DBNull.Value && reader["Role"] != DBNull.Value)
                {
                    return new UsersModel
                    {
                        Username = reader["Username"].ToString() ?? string.Empty,
                        Passwork = reader["Passwork"].ToString() ?? string.Empty,
                        Role = Convert.ToInt32(reader["Role"])//chuyen doi gia tri Role tu object sang int
                    };
                }
            }
            return null;
        }
    }
}
