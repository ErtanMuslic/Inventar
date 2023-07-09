using API.DTOs;
using AutoMapper;
using Inventar.Models;

namespace API.Mapping
{
    public class ApplicationMapping : Profile
    {
        public ApplicationMapping() 
        {
            CreateMap<InventoryDto, Inventory>();
        }
    }
}
