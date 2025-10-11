using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
<<<<<<< HEAD
using BT3_Nhom3_23WebC.Models;
=======
using Microsoft.Data.SqlClient;
namespace BT3_Nhom3_23WebC.DAL
{
    public class ProductRepository
    {
        private readonly string _connectionString;
        //dung DI de lay connection string tu appsettings.json
        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Ket noi khong ton tai trong cau hinh.");
        }
        //lay tat ca san pham tu database
        public List<Product> GetAllProducts()
        {
            var products = new List<Product>();
            string sql = "SELECT MaSP, TenSP, DonGia, DonGiaKhuyenMai, HinhAnh, MoTa, LoaiSP FROM Product_Test";
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
>>>>>>> origin/DoThe

public class ProductRepository
{
    private readonly string _connectionString;

    public ProductRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Chưa có kết nối trong cấu hình.");
    }

    // Lấy tất cả sản phẩm
    public List<Product> GetAllProducts()
    {
        var products = new List<Product>();
        string sql = "SELECT MaSP, TenSP, DonGia, DonGiaKhuyenMai, HinhAnh, MoTa, LoaiSP, MaDM FROM Products";

        using (var conn = new SqlConnection(_connectionString))
        using (var cmd = new SqlCommand(sql, conn))
        {
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        MaSP = reader["MaSP"].ToString() ?? "",
                        TenSP = reader["TenSP"].ToString() ?? "",
                        DonGia = Convert.ToInt32(reader["DonGia"]),
                        DonGiaKhuyenMai = Convert.ToInt32(reader["DonGiaKhuyenMai"]),
                        HinhAnh = reader["HinhAnh"].ToString() ?? "",
                        MoTa = reader["MoTa"].ToString() ?? "",
                        LoaiSP = reader["LoaiSP"].ToString() ?? "",
                        MaDM = Convert.ToInt32(reader["MaDM"])
                    });
                }
            }
        }
<<<<<<< HEAD
        return products;
    }

    // Thêm sản phẩm
    public bool AddProduct(Product product, out string errorMessage)
    {
        errorMessage = "";
        try
        {
            if (product == null)
            {
                errorMessage = "Product null.";
                return false;
            }

            string sql = @"INSERT INTO Products
                       (MaSP, TenSP, DonGia, DonGiaKhuyenMai, HinhAnh, MoTa, LoaiSP, MaDM)
                       VALUES
                       (@MaSP, @TenSP, @DonGia, @DonGiaKhuyenMai, @HinhAnh, @MoTa, @LoaiSP, @MaDM)";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaSP", product.MaSP ?? "");
                cmd.Parameters.AddWithValue("@TenSP", product.TenSP ?? "");
                cmd.Parameters.AddWithValue("@DonGia", product.DonGia);
                cmd.Parameters.AddWithValue("@DonGiaKhuyenMai", product.DonGiaKhuyenMai);
                cmd.Parameters.AddWithValue("@HinhAnh", product.HinhAnh ?? "");
                cmd.Parameters.AddWithValue("@MoTa", product.MoTa ?? "");
                cmd.Parameters.AddWithValue("@LoaiSP", product.LoaiSP ?? "");
                cmd.Parameters.AddWithValue("@MaDM", product.MaDM);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    errorMessage = "Không thêm được sản phẩm, rowsAffected = 0.";
                    return false;
                }
            }

            return true;
        }
        catch (SqlException ex)
        {
            errorMessage = $"Lỗi SQL: {ex.Message}";
            return false;
        }
        catch (Exception ex)
        {
            errorMessage = $"Lỗi: {ex.Message}";
            return false;
        }
=======
        public bool TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("✅ Kết nối thành công!");
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("❌ Lỗi kết nối: " + ex.Message);
                    return false;
                }
            }
        }

>>>>>>> origin/DoThe
    }


    // Lấy tất cả danh mục
    public List<DanhMuc> GetAllDanhMuc()
    {
        var danhMucs = new List<DanhMuc>();
        string sql = "SELECT MaDM, TenDM FROM DanhMuc";

        using (var conn = new SqlConnection(_connectionString))
        using (var cmd = new SqlCommand(sql, conn))
        {
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    danhMucs.Add(new DanhMuc
                    {
                        MaDM = Convert.ToInt32(reader["MaDM"]),
                        TenDM = reader["TenDM"].ToString() ?? ""
                    });
                }
            }
        }
        return danhMucs;
    }
    // Thêm phương thức để thêm danh mục mới
    public void AddDanhMuc(int maDM, string tenDM)
    {
        string sql = "INSERT INTO DanhMuc(MaDM, TenDM) VALUES(@MaDM, @TenDM)";
        using var conn = new SqlConnection(_connectionString);
        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@MaDM", maDM);
        cmd.Parameters.AddWithValue("@TenDM", tenDM);
        conn.Open();
        cmd.ExecuteNonQuery();
    }



}
