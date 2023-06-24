using Andreitoledo.GeekShopping.ProductAPI.Data.ValueObjects;
using Andreitoledo.GeekShopping.ProductAPI.Model;
using AutoMapper;

namespace Andreitoledo.GeekShopping.ProductAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig =  new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVO, Product>();
                config.CreateMap<Product, ProductVO>();
            });
            return mappingConfig;

        }
    }
}
