using Application.Query.Inventories;
using Infrastructure;
using MediatR;
using Inventar.Models;
using AutoMapper;
using API.DTOs;
using TechTalk.SpecFlow.CommonModels;

namespace API.Mediator.Inventories
{
    public record AddInventory(InventoryDto dto) : IRequest<Result<InventoryDto>>;
    public class AddInventory : IRequestHandler<AddInventoryQuery, Inventory>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AddInventory(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Inventory> Handle(AddInventoryQuery request, CancellationToken cancellationToken)
        {
           //var inventories = await _unitOfWork.Inventories.Add(request.Inventory);
            //_unitOfWork.Save();
            //return inventories;

            var newInventory = mapper.Map<API.Data.Inventory>(request.dto);
        }
    }
}
