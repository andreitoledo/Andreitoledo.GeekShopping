using Andreitoledo.GeekShopping.Web.Models;
using Andreitoledo.GeekShopping.Web.Services.IServices;

namespace Andreitoledo.GeekShopping.Web.Services
{
    public class CartService : ICartService
    {
        public Task<CartViewModel> AddItemToCart(CartViewModel cart, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ApplyCoupon(CartViewModel cart, string couponCode, string token)
        {
            throw new NotImplementedException();
        }

        public Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ClearCart(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCoupon(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFromCart(long cartId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<CartViewModel> UpdateCart(CartViewModel cart, string token)
        {
            throw new NotImplementedException();
        }
    }
}
