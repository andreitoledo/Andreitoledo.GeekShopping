using Andreitoledo.GeekShopping.Web.Models;
using Andreitoledo.GeekShopping.Web.Services.IServices;
using Andreitoledo.GeekShopping.Web.Utils;

namespace Andreitoledo.GeekShopping.Web.Services
{
    public class ProductService : IProductService
    {
        // HttpClient consome a API
        private readonly HttpClient _client;
        public const string BasePath = "api/v1/product";

        public ProductService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<ProductModel>> FindAllProducts()
        {
            var response = await _client.GetAsync(BasePath);
            return await response.ReadContentAs<List<ProductModel>>();
        }

        public async Task<ProductModel> FindProductById(long id)
        {
            var response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<ProductModel>();
        }

        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteProductById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
