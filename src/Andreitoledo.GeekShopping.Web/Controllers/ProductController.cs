using Andreitoledo.GeekShopping.Web.Models;
using Andreitoledo.GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Andreitoledo.GeekShopping.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        // Por ser microsserviços, a idéia não é referenciar todo o codigo da API
        // e somente os métodos que utilizaram.
        // Para esse método, busca na API o método FindAll em ProductController
        public async Task<IActionResult> ProductIndex()
        {
            var products = await _productService.FindAllProducts();
            return View(products);
        }

        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.CreateProduct(model);
                if (response != null) return RedirectToAction(
                     nameof(ProductIndex));
            }
            return View(model);
        }

    }
}
