using Microsoft.AspNetCore.Mvc;
using Products_Web.Models.Product;
using Products_Web.Services.Interfaces;

namespace Products_Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        public IActionResult Index()
        {
            var products = productService.GetAll();

            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateProductViewModel product)
        {
            productService.Add(product);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            productService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = productService.Get(id);

            return View(product);
        }

        /*[HttpPost]
        public IActionResult Edit(EditProductViewModel product)
        {
            productService.Edit(product);

            return RedirectToAction(nameof(Index));
        }*/
    }
}
