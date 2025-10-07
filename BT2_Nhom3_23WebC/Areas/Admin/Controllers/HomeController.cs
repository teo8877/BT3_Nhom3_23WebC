using Microsoft.AspNetCore.Mvc;

namespace BT2_Nhom3_23WebC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Admin Home Page";
            return View();
        }
    }
}
