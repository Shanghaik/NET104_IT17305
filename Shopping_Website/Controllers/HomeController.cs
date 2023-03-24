using Microsoft.AspNetCore.Mvc;
using Shopping_Website.IServices;
using Shopping_Website.Models;
using Shopping_Website.Services;
using System.Diagnostics;
using System.Drawing;

namespace Shopping_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices productServices; // Khai báo interface
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            productServices = new ProductServices();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            
            return View();
        }
        public IActionResult Test()
        {
            return View(); // Khi Action return về 1 view thì có 1 request
            // => Hiển thị ra view cùng tên với Action đó
        }
        public IActionResult Redirect()
        {
            return RedirectToAction("Test");
        }
        public IActionResult Show()
        {
            Product product = new Product()
            {
                Id = Guid.NewGuid(),
                Name = "Học Lại",
                Price = 672000,
                AvailableQuantity = 10,
                Supplier = "Family",
                Description = "Học English",
                Status = 1
            };
            return View(product); // Truyền tới View 1 object model
        }

        public IActionResult ShowListProduct()
        {
            var products = productServices.GetAllProducts();
            return View(products); // Truyền tới View 1 object model
        }

        public IActionResult Create() // Mở form
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)// Thực hiện việc thêm
        {
            productServices.CreateProduct(product);
            return RedirectToAction("ShowListProduct");
        }
        [HttpGet]
        public IActionResult Update(Guid id) // Mở form, truyền luôn sang form
        {
            var product = productServices.GetProductById(id);
            return View(product);
        }
        
        public IActionResult Update(Product p) // Mở form
        {
            if (productServices.UpdateProduct(p))
            {
                return RedirectToAction("ShowListProduct");
            }
            else return BadRequest();
        }
        public IActionResult Delete(Guid id)
        {
            productServices.DeleteProduct(id);
            return RedirectToAction("ShowListProduct");
        }
    
        public IActionResult TransferData()
        {
            /*
             * Ngoài cách truyền trực tiếp Obj model thì chúng
             * ta có thể truyền dữ liệu thông qua các cách sau:
             * Cách 1: Sử dụng ViewData: Truyền dữ liệu dựa theo
             * Viewdata theo dạng Key-Value, mỗi một ViewData["tên_key]
             * có thể lưu trữ được một kiểu dữ liệu (Generic)
             */
            List<string> ricons = new List<string>()
            {
                "Râu con", "Râu nhí", "Râu cha", 
                "Ri cha", "Sa tị", "Đều là", "Anh em"
            };
            ViewData["FAN"] = ricons;
            /*
             * Cách 2: Sử dụng ViewBag 
             * ViewBag không cần khởi tạo mà có thể đặt tên 
             * luôn cho thành phần vì đó là 1 lớp abstract
             * Dữ liệu trong ViewBag là Dynamic
             */
            double[] marks = { 4.5, 5.1, 9.9, 6.3, 2.8 };
            ViewBag.Marks = marks;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}