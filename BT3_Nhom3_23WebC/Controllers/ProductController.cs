 
using BT3_Nhom3_23WebC.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BT2_Nhom3_23WebC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository= productRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAllProducts();
            return View(products);
        }
    }
}
