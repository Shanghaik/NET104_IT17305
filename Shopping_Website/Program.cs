using Shopping_Website.IServices;
using Shopping_Website.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IProductServices, ProductServices>();
// builder.Services.AddSingleton<IProductServices, ProductServices>();
// builder.Services.AddScoped<IProductServices, ProductServices>();
/*
 * AddSingleton: Nếu Service được khởi tạo, nó sẽ tồn tại cho đến khi vòng đời
 * của ứng dụng kết thúc. Nếu các Request khác mà triển khai thì sẽ dùng lại 
 * chính service đó. Phù hợp cho các services có tính toàn cục và không thay đổi
 * AddScoped: Mỗi lần có http Request thì sẽ tạo ra services 1 lần và được giữ
 * nguyên trong quá trình request được xử lý. Loại này sẽ được sử dụng cho các
 * services với những yêu cầu http cụ thể.
 * Adđ transient: Tạo mới services mỗi khi có request. Với mỗi yêu cầu http sẽ 
 * nhận được một đối tượng services khác nhau. Phù hợp cho các services mà có thể
 * phụ vụ nhiều yêu cầu http request.
 */


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
