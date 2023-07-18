using Infrastructure;
using MediatR;
using Inventar.Models;
using AutoMapper;
using API.DTOs;

namespace API.Mediator.Inventories
{
    public record AddInventoryHandler(InventoryDto inv_dto) : IRequest<InventoryDto>;
    public class AddInventory : IRequestHandler<AddInventoryHandler, InventoryDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public AddInventory(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        
        }
        public async Task<InventoryDto> Handle(AddInventoryHandler request, CancellationToken cancellationToken)
        {
            var newInventory = _mapper.Map<Inventory>(request.inv_dto);
           await _unitOfWork.Inventories.Add(newInventory);
            _unitOfWork.Save();
            var inventory = _mapper.Map<InventoryDto>(newInventory);
            return inventory;
        }
    }
}
