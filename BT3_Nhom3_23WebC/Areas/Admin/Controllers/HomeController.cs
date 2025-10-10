using BT3_Nhom3_23WebC.DAL;
using Microsoft.AspNetCore.Mvc;
using BT3_Nhom3_23WebC.Models;
namespace BT2_Nhom3_23WebC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly UserRepository _userReposiory;
        public HomeController(UserRepository userReposiory)
        {
            _userReposiory = userReposiory;
        }
        public IActionResult Index()
        {
            // Lấy username và password từ session
            var username = HttpContext.Session.GetString("Username");
  
            var role = HttpContext.Session.GetInt32("Role");
            if(string.IsNullOrEmpty(username) || role != 1)
            {
                return RedirectToAction("Index", "Login", new { area = "" });
            }
            ViewBag.Username = username;
            ViewBag.PageName = "Admin Home";
            return View();
        }
    }
}
