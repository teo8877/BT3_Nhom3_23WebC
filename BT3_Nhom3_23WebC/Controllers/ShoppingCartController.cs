using BT2_Nhom3_23WebC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BT2_Nhom3_23WebC.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            var items = new List<ShoppingCartItem>
        {
            new ShoppingCartItem { Name = "Ut eu feugiat", ImageUrl = "images/product/01.jpg", Description = "", Quantity = 1, Price = 240 },
            new ShoppingCartItem { Name = "Donec Est Nisi", ImageUrl = "images/product/02.jpg", Description = "Validate <a href=\"http://validator.w3.org/check?uri=referer\" rel=\"nofollow\"><strong>XHTML</strong></a> &amp; <a href=\"http://jigsaw.w3.org/css-validator/check/referer\" rel=\"nofollow\"><strong>CSS</strong></a>", Quantity = 2, Price = 160 }
        };

            var total = items.Sum(i => i.Price * i.Quantity);

            var model = new ShoppingCartViewModel
            {
                Items = items,
                Total = total
            };

            return View(model);  
        }
    }
}
