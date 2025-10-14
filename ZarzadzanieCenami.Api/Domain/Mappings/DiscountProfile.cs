using AutoMapper;
using ZarzadzanieCenami.Api.Domain.Dto;
using ZarzadzanieCenami.Api.Domain.Entities;

namespace ZarzadzanieCenami.Api.Domain.Mappings
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
             CreateMap<Discount, DiscountDto>()
                .ForMember(dest => dest.ProductIds,
                       opt => opt.MapFrom(src => src.Products.Select(p => p.Id)))
                .ForMember(dest => dest.ShopIds,
                       opt => opt.MapFrom(src => src.Shops.Select(p => p.Id)))
                ;
        }
    }
}
