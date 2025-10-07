using BT2_Nhom3_23WebC.Models;
 
using BT3_Nhom3_23WebC.DAL;
using BT2_Nhom3_23WebC.Middleware; // Thêm namespace Middleware

var builder = WebApplication.CreateBuilder(args);

//lấy chuối kết nối từ file appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    
 
 
// Packge: SqlServer, Tools, Gió lõi 
//create csdl: Tao Migration(kich ban DB) Add.Migration InitialCreate, Apply: Update-Database
// Add services to the container.
builder.Services.AddControllersWithViews();

//DI for AddStaticAssets
//DI cau 2;
builder.Services.AddScoped<ProductRepository>();//co the dung AddSingleton

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<RequestLogMiddleware>(); // Đăng ký middleware ghi log

app.UseHttpsRedirection();
app.UseStaticFiles();// For the wwwroot folder
app.UseRouting();
app.UseAuthorization();

// Đọc danh sách sản phẩm từ db.json qua Middleware
//app.UseMiddleware<ProductDbMiddleware>(Path.Combine(app.Environment.ContentRootPath, "db.json"));

app.MapStaticAssets();

// Routing cho Area (Admin)
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

// Routing mặc định cho trang người dùng
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
