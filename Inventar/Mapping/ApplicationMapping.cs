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
            CreateMap<Worker, WorkerDto>();
            CreateMap<WorkerDto, Worker>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid()));
            CreateMap<Room,RoomDto>();
            CreateMap<RoomDto, Room>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Workers,
                opt => opt.MapFrom(src => new List<WorkerDto>()))
                .ForMember(dest => dest.Inventory,
                opt => opt.MapFrom(src => new List<InventoryDto>()));
        }
    }
}
