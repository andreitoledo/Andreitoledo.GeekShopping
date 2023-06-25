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
            var products = _productService.FindAllProducts;
            return View(products);
        }
    }
}
