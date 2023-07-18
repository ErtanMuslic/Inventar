using Infrastructure;
using MediatR;
using Inventar.Models;
using API.DTOs;
using AutoMapper;

namespace API.Mediator.Inventories
{
    public record GetAllInventoriesQuery() : IRequest<IEnumerable<InventoryDto>>;
    public class GetAllInventories : IRequestHandler<GetAllInventoriesQuery, IEnumerable<InventoryDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllInventories(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<InventoryDto>> Handle(GetAllInventoriesQuery request, CancellationToken cancellationToken)
        {
            var invenotries = await _unitOfWork.Inventories.GetAll();
            var res = invenotries.Select(inv => _mapper.Map<InventoryDto>(inv));
            return res;
        }
    }
}
