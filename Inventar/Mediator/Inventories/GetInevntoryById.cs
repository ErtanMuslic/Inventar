using Application.Query.Inventories;
using Infrastructure;
using User.Models;
using MediatR;

namespace API.Mediator.Inventories
{
    public class GetInevntoryById : IRequestHandler<GetInventoryByIdQuery, Inventory>
    {
        private readonly IUnitOfWork _unitOfWork;    
        public GetInevntoryById(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Inventory> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            var inventories = await _unitOfWork.Inventories.GetById(request.Id);
            return inventories;
        }
    }
}
