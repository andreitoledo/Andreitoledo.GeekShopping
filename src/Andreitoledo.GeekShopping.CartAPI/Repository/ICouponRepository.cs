using Andreitoledo.GeekShopping.CartAPI.Data.ValueObjects;

namespace Andreitoledo.GeekShopping.CartAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCoupon(string couponCode, string token);
    }
}
