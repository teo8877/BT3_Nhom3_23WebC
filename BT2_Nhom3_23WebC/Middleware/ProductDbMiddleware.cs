//using System.Text.Json;
//using BT2_Nhom3_23WebC.Models;

//namespace BT2_Nhom3_23WebC.Middleware
//{
//    public class ProductDbMiddleware
//    {
//        private readonly RequestDelegate _next;
//        private readonly string _dbPath;

//        public ProductDbMiddleware(RequestDelegate next, string dbPath)
//        {
//            _next = next;
//            _dbPath = dbPath;
//        }

//        public async Task InvokeAsync(HttpContext context, ProductService productService)
//        {
//            if (!productService.ProductsLoaded)
//            {
//                using var stream = new FileStream(_dbPath, FileMode.Open, FileAccess.Read);//mở file db.json để đọc dữ liệu
//                var db = await JsonSerializer.DeserializeAsync<ProductDb>(stream);//đọc dữ liệu từ file db.json và chuyển đổi thành đối tượng ProductDb
//                if (db?.products != null)//nếu dữ liệu không rỗng thì gọi phương thức SetProducts để lưu danh sách sản phẩm vào ProductService
//                {
//                    productService.SetProducts(db.products);
//                }
//            }
//            await _next(context);
//        }
//    }

//    public class ProductDb
//    {
//        public List<Product> products { get; set; }
//    }
//}
