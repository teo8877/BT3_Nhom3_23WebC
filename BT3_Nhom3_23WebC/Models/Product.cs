using System.ComponentModel.DataAnnotations;

namespace BT3_Nhom3_23WebC.Models
{
    public class Product
    {
        [Key]
        [Required(ErrorMessage = "Mã sản phẩm không được để trống")]
        [StringLength(20, ErrorMessage = "Mã sản phẩm tối đa 20 ký tự")]
        public string MaSP { get; set; }

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm tối đa 100 ký tự")]
        public string TenSP { get; set; }

        [Required(ErrorMessage = "Đơn giá không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Đơn giá phải lớn hơn 0")]
        public int DonGia { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Đơn giá khuyến mãi phải là số dương hoặc bằng 0")]
        public int DonGiaKhuyenMai { get; set; }

        [Required(ErrorMessage = "Hình ảnh không được để trống")]
        [StringLength(255, ErrorMessage = "Đường dẫn hình ảnh tối đa 255 ký tự")]
        public string HinhAnh { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        [StringLength(1000, ErrorMessage = "Mô tả tối đa 1000 ký tự")]
        public string MoTa { get; set; }

        [Required(ErrorMessage = "Loại sản phẩm không được để trống")]
        [StringLength(50, ErrorMessage = "Loại sản phẩm tối đa 50 ký tự")]
        public string LoaiSP { get; set; }

        public int MaDM { get; set; }
    }
}
