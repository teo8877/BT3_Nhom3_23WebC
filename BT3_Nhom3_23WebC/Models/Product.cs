using System.ComponentModel.DataAnnotations;

namespace BT3_Nhom3_23WebC.Models
{
    public class Product
    {
        [Key]
        public required string MaSP { get; set; }
        public required string TenSP { get; set; }
        public int DonGia { get; set; }
        public int DonGiaKhuyenMai { get; set; }
        public required string HinhAnh { get; set; }
        public required string MoTa { get; set; }
        public required string LoaiSP { get; set; }
    }
}
