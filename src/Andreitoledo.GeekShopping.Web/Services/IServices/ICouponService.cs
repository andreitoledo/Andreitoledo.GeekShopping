using Andreitoledo.GeekShopping.Web.Models;

namespace Andreitoledo.GeekShopping.Web.Services.IServices
{
    public interface ICouponService
    {
        Task<CouponViewModel> GetCoupon(string code, string token);
        
    }
}
