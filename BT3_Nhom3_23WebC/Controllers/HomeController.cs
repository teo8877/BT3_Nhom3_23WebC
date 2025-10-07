using System.Diagnostics;
 
using BT3_Nhom3_23WebC.DAL;
using Microsoft.AspNetCore.Mvc;
using BT3_Nhom3_23WebC.Models;
namespace BT3_Nhom3_23WebC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ProductRepository _productRepository;

        public HomeController(ILogger<HomeController> logger,ProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            ViewBag.PageName = "Home";
            var products= _productRepository.GetAllProducts();
            return View(products);
        }
      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
