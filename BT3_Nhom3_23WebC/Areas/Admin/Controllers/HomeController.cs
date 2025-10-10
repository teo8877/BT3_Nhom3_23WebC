using BT3_Nhom3_23WebC.DAL;
using Microsoft.AspNetCore.Mvc;
using BT3_Nhom3_23WebC.Models;
 using BT3_Nhom3_23WebC.DAL;
namespace BT2_Nhom3_23WebC.Areas.Admin.Controllers
{
 [Area("Admin")]//khai bao Area
    public class HomeController : Controller
    {

       
        private readonly UserRepository _userReposiory;
        public HomeController(UserRepository userReposiory)
        {
            _userReposiory = userReposiory;
        }
        public IActionResult Index(string username, string passwork)
        {
            //var username = HttpContext.Session.GetString("Username");
            //var role = HttpContext.Session.GetInt32("Role");
            //if (string.IsNullOrEmpty(username) || role != 1)
            //{
            //    return RedirectToAction("Index", "Login", new { area = "" });
            //}
            //ViewData["Title"] = "Admin Home Page";
            //ViewBag.Username = username;

            //// Truyền danh sách sản phẩm cho view, nếu chưa có thì truyền danh sách rỗng
            //var products = new List<Product>(); // hoặc lấy từ ProductRepository nếu có
            //return View(products);

            var users=_userReposiory.Authenticate(username ,passwork);
            if (User != null)
            {
                HttpContext.Session.SetString("Username", users.Username);
                HttpContext.Session.SetInt32("Role", users.Role);
                if(users !=null)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }

            }
            var products = new List<Product>();
            return View(products);

        }
    }
}
