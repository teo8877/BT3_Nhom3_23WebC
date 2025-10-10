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
        public IActionResult Add(Products product)
        {
            ViewBag.Categories = _productRepository.GetAllDanhMuc()
                .Select(d => new SelectListItem
                {
                    Value = d.MaDM.ToString(),
                    Text = d.TenDM
                }).ToList();

            if (!ModelState.IsValid)
                return View(product);

            _productRepository.AddProduct(product);
            return RedirectToAction("Index");
        }
    }
}
