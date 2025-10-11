using BT3_Nhom3_23WebC.DAL;
using Microsoft.AspNetCore.Mvc;

namespace BT3_Nhom3_23WebC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductApiController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // API: GET /api/ProductApi
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return Ok(products); // trả về JSON
        }
        [HttpGet("testdb")]
        public IActionResult TestDb()
        {
            var result = _productRepository.TestConnection();
            return Ok(result);
        }

    }
}
