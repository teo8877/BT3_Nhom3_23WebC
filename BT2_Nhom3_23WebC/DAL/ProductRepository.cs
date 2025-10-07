using BT2_Nhom3_23WebC.Models;
 using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
namespace BT3_Nhom3_23WebC.DAL
{
    public class ProductRepository
    {
        private readonly string _connectionString;
        //dung DI de lay connection string tu appsettings.json
        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");//lay connection string tu appsettings.json voi key la DefaultConnection
        }
        //lay tat ca san pham tu database
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            string sql = "SELECT MaSP, TenSP, DonGia, DonGiaKhuyenMai, HinhAnh, MoTa, LoaiSP FROM Products";
            //tao 1 doi tuong tu SqlConnection de doc va dam bao ket noi do tu dong dong sau khi su dung xong
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var product = new Product
                                {
                                    MaSP = reader["MaSP"].ToString() ?? string.Empty,
                                    TenSP = reader["TenSP"].ToString() ?? string.Empty,
                                    DonGia = reader["DonGia"] != DBNull.Value ? Convert.ToInt32(reader["DonGia"]) : 0,
                                    DonGiaKhuyenMai = reader["DonGiaKhuyenMai"] != DBNull.Value ? Convert.ToInt32(reader["DonGiaKhuyenMai"]) : 0,
                                    HinhAnh = reader["HinhAnh"].ToString() ?? string.Empty,
                                    MoTa = reader["MoTa"].ToString() ?? string.Empty,
                                    LoaiSP = reader["LoaiSP"].ToString() ?? string.Empty
                                };
                                products.Add(product);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Log exception (you can use a logging framework here)
                        Console.WriteLine($"Error fetching products: {ex.Message}");
                        // Optionally, rethrow or handle the exception as needed
                    }
                }
                return products;
            }
        }
        public void AddProduct(Product product)
        {
            string sql = @"INSERT INTO Products (MaSP, TenSP, DonGia, DonGiaKhuyenMai, HinhAnh, MoTa, LoaiSP)
                   VALUES (@MaSP, @TenSP, @DonGia, @DonGiaKhuyenMai, @HinhAnh, @MoTa, @LoaiSP)";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@MaSP", product.MaSP);
                    command.Parameters.AddWithValue("@TenSP", product.TenSP);
                    command.Parameters.AddWithValue("@DonGia", product.DonGia);
                    command.Parameters.AddWithValue("@DonGiaKhuyenMai", product.DonGiaKhuyenMai);
                    command.Parameters.AddWithValue("@HinhAnh", product.HinhAnh);
                    command.Parameters.AddWithValue("@MoTa", product.MoTa);
                    command.Parameters.AddWithValue("@LoaiSP", product.LoaiSP);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
