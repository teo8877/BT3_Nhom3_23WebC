using BT3_Nhom3_23WebC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using BT3_Nhom3_23WebC.DAL;

namespace BT3_Nhom3_23WebC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Admin Product Page";
            var products = _productRepository.GetAllProducts();
            return View(products);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Categories = _productRepository.GetAllDanhMuc()
                .Select(d => new SelectListItem
                {
                    Value = d.MaDM.ToString(),
                    Text = d.TenDM
                }).ToList();

            return View();
        }

        [HttpPost]
        //public IActionResult Add(Product product)
        //{
        //    ViewBag.Categories = _productRepository.GetAllDanhMuc()
        //        .Select(d => new SelectListItem
        //        {
        //            Value = d.MaDM.ToString(),
        //            Text = d.TenDM
        //        }).ToList();

        //    // Debug ModelState
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors)
        //                      .Select(e => e.ErrorMessage).ToList();
        //        ModelState.AddModelError("", "Lỗi validate: " + string.Join(", ", errors));
        //        return View(product);
        //    }

        //    // Thêm sản phẩm
        //    if (!_productRepository.AddProduct(product, out string errorMessage))
        //    {
        //        ModelState.AddModelError("", "Thêm thất bại: " + errorMessage);
        //        return View(product);
        //    }

        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        public IActionResult Add(Product product, int? NewMaDM, string NewCategoryName)
        {
            ViewBag.Categories = _productRepository.GetAllDanhMuc()
                .Select(d => new SelectListItem
                {
                    Value = d.MaDM.ToString(),
                    Text = d.TenDM
                }).ToList();

            if (!ModelState.IsValid)
                return View(product);

            if (!string.IsNullOrEmpty(NewCategoryName) && NewMaDM.HasValue)
            {
                // Thêm danh mục mới với mã do người dùng nhập
                _productRepository.AddDanhMuc(NewMaDM.Value, NewCategoryName);
                product.MaDM = NewMaDM.Value;
            }

            if (!_productRepository.AddProduct(product, out string errorMessage))
            {
                ModelState.AddModelError("", "Thêm thất bại: " + errorMessage);
                return View(product);
            }

            return RedirectToAction("Index");
        }





    }
}
