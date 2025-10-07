using Microsoft.AspNetCore.Mvc;
using BT2_Nhom3_23WebC.Models;
using System.Text.Json;
using BT3_Nhom3_23WebC.DAL;
namespace BT2_Nhom3_23WebC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Area("Admin")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Admin Product Page";
            return View();
        }

        [Area("Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                // Nếu dữ liệu không hợp lệ, trả lại view với thông báo lỗi
                return View(product);
            }
            _productRepository.AddProduct(product);
            // Chuyển về trang danh sách
            return RedirectToAction("Index");
        }
    }

    public class ProductDb
    {
        public List<Product> products { get; set; } = new List<Product>();
    }
}
