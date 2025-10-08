using AutoMapper;

namespace ZarzadzanieCenami.Api.Domain.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, Dto.ProductDto>().ReverseMap();
        }
    }
}
