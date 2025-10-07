using BT2_Nhom3_23WebC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BT2_Nhom3_23WebC.Controllers
{
    public class CheckoutController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // Lấy tổng tiền từ giỏ hàng thực tế
            var model = new CheckoutViewModel
            {
                Total = 560 // Ví dụ cứng, thực tế lấy từ ShoppingCart
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(CheckoutViewModel model)
        {
            if (!model.TermsAccepted)
            {
                ModelState.AddModelError("TermsAccepted", "Bạn phải đồng ý với điều khoản.");
            }
            if (ModelState.IsValid)
            {
                // Xử lý đơn hàng, lưu vào DB, gửi email, v.v.
                return RedirectToAction("Success");
            }
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
