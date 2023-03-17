using Microsoft.AspNetCore.Mvc;
using Shopping_Website.IServices;
using Shopping_Website.Models;
using Shopping_Website.Services;
using System.Diagnostics;

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
        public IActionResult Create(Product product)
        {
            productServices.CreateProduct(product);
            return RedirectToAction("ShowListProduct");
        }

        public IActionResult Update()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}