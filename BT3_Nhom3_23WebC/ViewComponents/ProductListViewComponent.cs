using Microsoft.AspNetCore.Mvc;
using BT3_Nhom3_23WebC.DAL;
using BT3_Nhom3_23WebC.Models;
using System.Collections.Generic;

namespace BT3_Nhom3_23WebC.ViewComponents
{
    public class ProductListViewComponent : ViewComponent
    {
        private readonly ProductRepository _productRepo;

        public ProductListViewComponent(ProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public IViewComponentResult Invoke()
        {
            // Lấy danh sách sản phẩm (ví dụ 5 sản phẩm đầu)
            var products = _productRepo.GetAllProducts().Take(5).ToList();
            return View(products);
        }
    }
}
