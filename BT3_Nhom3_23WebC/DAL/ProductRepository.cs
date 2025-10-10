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
    public List<Product> GetAllProducts()
    {
        var products = new List<Product>();
        string sql = "SELECT MaSP, TenSP, DonGia, DonGiaKhuyenMai, HinhAnh, MoTa, LoaiSP, MaDM FROM Products";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
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
        return products;
    }

    // Thêm sản phẩm
    public void AddProduct(Product product)
    {
        string sql = @"INSERT INTO Products
                   (MaSP, TenSP, DonGia, DonGiaKhuyenMai, HinhAnh, MoTa, LoaiSP, MaDM)
                   VALUES
                   (@MaSP, @TenSP, @DonGia, @DonGiaKhuyenMai, @HinhAnh, @MoTa, @LoaiSP, @MaDM)";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.Parameters.AddWithValue("@MaSP", product.MaSP);
            cmd.Parameters.AddWithValue("@TenSP", product.TenSP);
            cmd.Parameters.AddWithValue("@DonGia", product.DonGia);
            cmd.Parameters.AddWithValue("@DonGiaKhuyenMai", product.DonGiaKhuyenMai);
            cmd.Parameters.AddWithValue("@HinhAnh", product.HinhAnh);
            cmd.Parameters.AddWithValue("@MoTa", product.MoTa);
            cmd.Parameters.AddWithValue("@LoaiSP", product.LoaiSP); // ✅ sửa đúng
            cmd.Parameters.AddWithValue("@MaDM", product.MaDM);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }


    // Lấy tất cả danh mục
    public List<DanhMuc> GetAllDanhMuc()
    {
        var danhMucs = new List<DanhMuc>();
        string sql = "SELECT MaDM, TenDM FROM DanhMuc";

        using (SqlConnection conn = new SqlConnection(_connectionString))
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
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
}
