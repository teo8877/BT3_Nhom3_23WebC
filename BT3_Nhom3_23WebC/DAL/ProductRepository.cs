using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
 
using BT3_Nhom3_23WebC.Models;


public class ProductRepository
{
    private readonly string _connectionString;

    public ProductRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Chưa có kết nối trong cấu hình.");
    }

    // Lấy tất cả sản phẩm
    public List<Products> GetAllProducts()
    {
        var products = new List<Products>();
        string sql = "SELECT MaSP, TenSP, DonGia, DonGiaKhuyenMai, HinhAnh, MoTa, LoaiSP, MaDM FROM Products";

        using (var conn = new SqlConnection(_connectionString))
        using (var cmd = new SqlCommand(sql, conn))
        {
            conn.Open();
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    products.Add(new Products
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
 
        return products;
    }

    // Thêm sản phẩm
    public bool AddProduct(Products product, out string errorMessage)
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

 

}
