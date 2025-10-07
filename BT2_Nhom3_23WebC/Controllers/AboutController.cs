using BT2_Nhom3_23WebC.Models;
using Microsoft.AspNetCore.Mvc;

namespace BT2_Nhom3_23WebC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            var model = new AboutViewModel
            {
                Title = "About",
                Description = "Donec sapien. Nam ac nunc. Aliquam fermentum cursus risus...",
                Features = new List<string>
            {
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
            "Pellentesque quis nulla id orci malesuada porta posuere quis massa.",
            "Nunc vitae purus non augue scelerisque ultricies vitae et velit quis.",
            "Aliquam fermentum cursus risus aliquam erat volutpat.",
            "Morbi a augue eget orci sodales blandit morbiet mi in mi eleifend adipiscing."
            },
                SubTitle = "Praesent pede massa, feugiat auctor",
                SubDescription = "Nam nec leo. Curabitur quis eros a arcu feugiat egestas...",
                Blockquote = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque quis nulla id orci malesuada porta posuere quis massa. Nunc vitae purus non augue scelerisque ultricies vitae et velit quis nulla id orci malesua."
            };
            return View(model);
        }
    }
}
