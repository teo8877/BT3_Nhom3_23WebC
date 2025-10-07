using Microsoft.AspNetCore.Mvc;

namespace BT2_Nhom3_23WebC.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index(int id)
        {
            // Giả sử lấy dữ liệu từ DB hoặc hardcode
            var product = new Models.ProductDetailModel
            {
                Name = "Yellow Flowers",
                ImageUrl = "/images/product/image_01.jpg",
                LargeImageUrl = "/images/product/image_01_l.jpg",
                Price = 240,
                Availability = "In Stock",
                Description = "Sed ullamcorper nunc at magna egestas fermentum. Etiam turpis orci, condimentum luctus orci id, elementum vulputate nunc. Donec diam turpis, iaculis vitae feugiat ac, molestie at odio. Nullam tincidunt est ac sagittis ultricies...",
                Quantity = 1
            };
            return View(product);
        }
    }
}
