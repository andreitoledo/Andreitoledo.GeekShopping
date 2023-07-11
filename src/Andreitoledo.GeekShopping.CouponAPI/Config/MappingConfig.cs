using Andreitoledo.GeekShopping.CouponAPI.Data.ValueObjects;
using Andreitoledo.GeekShopping.CouponAPI.Model;
using AutoMapper;

namespace Andreitoledo.GeekShopping.CouponAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig =  new MapperConfiguration(config =>
            {
               config.CreateMap<CouponVO, Coupon>().ReverseMap();               

            });
            return mappingConfig;

        }
    }
}
