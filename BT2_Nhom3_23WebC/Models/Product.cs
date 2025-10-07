using System.ComponentModel.DataAnnotations;

namespace BT3_Nhom3_23WebC.Models
{
    public class Product
    {
        [Key]  
        public string MaSP { get; set; } = string.Empty;
        public string TenSP { get; set; } = string.Empty;
        public int  DonGia { get; set; }
        public int  DonGiaKhuyenMai { get; set; }
        public string HinhAnh { get; set; } = string.Empty;
        public string MoTa { get; set; } = string.Empty;
        public string LoaiSP { get; set; } = string.Empty;
    }
}
