using BT3_Nhom3_23WebC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using BT3_Nhom3_23WebC.DAL;
namespace BT3_Nhom3_23WebC.Areas.Admin.Controllers
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
            var products = _productRepository.GetAllProducts();
            return View(products);
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
                return View(product);
            }
            _productRepository.AddProduct(product);
            return RedirectToAction("Index");
        }
    }
}

