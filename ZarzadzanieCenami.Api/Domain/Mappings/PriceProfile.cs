using AutoMapper;
using ZarzadzanieCenami.Api.Domain.Dto;
using ZarzadzanieCenami.Api.Domain.Entities;

namespace ZarzadzanieCenami.Api.Domain.Mappings
{
    public class PriceProfile : Profile
    {
        public PriceProfile()
        {
             CreateMap<Price, PriceDto>().ReverseMap();
        }
    }
}
