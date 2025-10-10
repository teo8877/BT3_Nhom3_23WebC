using BT3_Nhom3_23WebC.Models;
using Microsoft.AspNetCore.Mvc;
using BT3_Nhom3_23WebC.DAL;
using Microsoft.AspNetCore.Http;

namespace BT3_Nhom3_23WebC.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserRepository _userRepository;

        public LoginController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Hiển thị trang đăng nhập
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username, string password)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                ViewBag.Error = "Vui lòng nhập tài khoản và mật khẩu!";
                return View();
            }

            var user = _userRepository.Authenticate(username, password);

            if (user != null)
            {
                HttpContext.Session.SetString("Username", user.Username);
                HttpContext.Session.SetInt32("Role", user.Role);

                if (user.Role == 1) // admin
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                else if (user.Role == 2) // user
                    return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Sai tài khoản hoặc mật khẩu!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
