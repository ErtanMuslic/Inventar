using API.DTOs;
using AutoMapper;
using Inventar.Models;

namespace API.Mapping
{
    public class ApplicationMapping : Profile
    {
        public ApplicationMapping() 
        {
            CreateMap<Inventory, InventoryDto>();
            CreateMap<InventoryDto, Inventory>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid()));

        }
    }
}
