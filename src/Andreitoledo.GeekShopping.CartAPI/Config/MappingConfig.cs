
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
                //config.CreateMap<ProductVO, Product>();
                //config.CreateMap<Product, ProductVO>();
            });
            return mappingConfig;

        }
    }
}
