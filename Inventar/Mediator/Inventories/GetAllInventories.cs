using Infrastructure;
using MediatR;
using Inventar.Models;
using API.DTOs;
using AutoMapper;

namespace API.Mediator.Inventories
{
    public record GetAllInventoriesHandler() : IRequest<IEnumerable<InventoryDto>>;
    public class GetAllInventories : IRequestHandler<GetAllInventoriesHandler, IEnumerable<InventoryDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllInventories(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<InventoryDto>> Handle(GetAllInventoriesHandler request, CancellationToken cancellationToken)
        {
            var inventories = await _unitOfWork.Inventories.GetAll();
            var result = inventories.Select(inv => _mapper.Map<InventoryDto>(inv));
            return result;
        }
    }
}
