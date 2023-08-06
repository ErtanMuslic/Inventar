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


            CreateMap<Room, RoomDto>();
            CreateMap<RoomDto, Room>()
                .ForMember(dest => dest.Id,
                opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.Boss,
               opt => opt.MapFrom(src => src.Worker != null ? $"{src.Worker.Name} {src.Worker.Surname}" : ""))
                .AfterMap((src, dest) =>
                {
                    if (src.Worker != null)
                    {
                        dest.Worker.Qualification = "Boss";
                    }
                });
        }
    }
}
