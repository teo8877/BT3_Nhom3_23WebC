using System.ComponentModel.DataAnnotations;

namespace BT2_Nhom3_23WebC.Models
{
    public class Product
    {

    //    MaSP NVARCHAR(10) PRIMARY KEY,
    //TenSP NVARCHAR(100),
    //DonGia INT,
    //DonGiaKhuyenMai INT,
    //HinhAnh NVARCHAR(200),
    //MoTa NVARCHAR(500),
    //LoaiSP NVARCHAR(50)
        [Key]  
        public string MaSP { get; set; } = string.Empty;

        // Tên sản phẩm
        public string TenSP { get; set; } = string.Empty;

        // Đơn giá gốc - dùng decimal cho số tiền
        public int  DonGia { get; set; }

        // Giá sau khuyến mãi - cũng dùng decimal
        public int  DonGiaKhuyenMai { get; set; }

        // Đường dẫn ảnh sản phẩm
        public string HinhAnh { get; set; } = string.Empty;

        // Mô tả sản phẩm
        public string MoTa { get; set; } = string.Empty;

        // Loại sản phẩm
        public string LoaiSP { get; set; } = string.Empty;
    }
}
