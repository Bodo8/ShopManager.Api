using AutoMapper;
using ZarzadzanieCenami.Api.Domain.Dto;
using ZarzadzanieCenami.Api.Domain.Entities;

namespace ZarzadzanieCenami.Api.Domain.Mappings
{
    public class DiscountProfile : Profile
    {
        public DiscountProfile()
        {
             CreateMap<Discount, DiscountDto>().ReverseMap();
        }
    }
}
