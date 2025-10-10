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
        private readonly UserRepository _userRepository;

        public HomeController(ILogger<HomeController> logger, ProductRepository productRepository, UserRepository userRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {

            var role = HttpContext.Session.GetInt32("Role");
            if (role == 1)
                return RedirectToAction("Index", "Home", new { area = "Admin" });

            ViewBag.Username = HttpContext.Session.GetString("Username");
            ViewBag.PageName = "Home";
            return View(_productRepository.GetAllProducts());
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
