using AutoMapper;
using ZarzadzanieCenami.Api.Domain.Dto;
using ZarzadzanieCenami.Api.Domain.Entities;

namespace ZarzadzanieCenami.Api.Domain.Mappings
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
