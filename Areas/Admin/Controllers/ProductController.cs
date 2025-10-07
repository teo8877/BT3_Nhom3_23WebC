using Microsoft.AspNetCore.Mvc;
using BT2_Nhom3_23WebC.Models;
using System.Text.Json;

namespace BT2_Nhom3_23WebC.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            ViewData["Title"] = "Admin Product Page";
            return View();
        }

        [Area("Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Area("Admin")]
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(product.MaSP) || string.IsNullOrWhiteSpace(product.TenSP))
            {
                ModelState.AddModelError("", "Vui lòng nh?p ??y ?? thông tin s?n ph?m.");
                return View(product);
            }
            // ???ng d?n t?i db.json
            var dbPath = Path.Combine(Directory.GetCurrentDirectory(), "db.json");
            ProductDb db;
            // ??c d? li?u c?
            using (var stream = new FileStream(dbPath, FileMode.Open, FileAccess.Read))
            {
                db = JsonSerializer.Deserialize<ProductDb>(stream) ?? new ProductDb { products = new List<Product>() };
            }
            // Thêm s?n ph?m m?i
            db.products.Add(product);
            // Ghi l?i vào file
            using (var stream = new FileStream(dbPath, FileMode.Create, FileAccess.Write))
            {
                JsonSerializer.Serialize(stream, db, new JsonSerializerOptions { WriteIndented = true });
            }
            // Chuy?n v? trang danh sách
            return RedirectToAction("Index");
        }
    }

    public class ProductDb
    {
        public List<Product> products { get; set; } = new List<Product>();
    }
}
