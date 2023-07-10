
using Andreitoledo.GeekShopping.CartAPI.Data.ValueObjects;
using Andreitoledo.GeekShopping.CartAPI.Model;
using AutoMapper;

namespace Andreitoledo.GeekShopping.CartAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig =  new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>().ReverseMap();
                config.CreateMap<CartHeaderVO, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailVO, CartDetail>().ReverseMap();
                config.CreateMap<CartVO, Cart>().ReverseMap();

            });
            return mappingConfig;

        }
    }
}
