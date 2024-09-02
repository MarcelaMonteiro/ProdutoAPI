using AutoMapper;
using ProdutoApp.API.Dtos;
using ProdutoApp.Data.Entities;

namespace ProdutoApp.API.Mappings
{
    public class ProfileMap : Profile
    {
        public ProfileMap()
        {
            CreateMap<Product, ProductResponseDto>();
            
            CreateMap<ProductRequestDto, Product>();

            CreateMap<Product, ProductDashboardDto>();
        }
    }
}
