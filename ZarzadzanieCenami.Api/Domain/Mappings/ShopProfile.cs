using AutoMapper;
using ZarzadzanieCenami.Api.Domain.Dto;
using ZarzadzanieCenami.Api.Domain.Entities;

namespace ZarzadzanieCenami.Api.Domain.Mappings
{
    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<Shop, ShopDto>().ReverseMap();
        }
    }
}
