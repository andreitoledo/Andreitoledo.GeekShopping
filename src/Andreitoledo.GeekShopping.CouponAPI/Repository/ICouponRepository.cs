using Andreitoledo.GeekShopping.CouponAPI.Data.ValueObjects;

namespace Andreitoledo.GeekShopping.CouponAPI.Repository
{
    public interface ICouponRepository
    {
        Task<CouponVO> GetCouponByCouponCode(string couponCode);
    }
}
