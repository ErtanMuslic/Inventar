using Infrastructure;
using MediatR;
using Inventar.Models;
using Inventar.Persistance;

namespace API.Mediator.Inventories
{
    public record GetInventoryByIdQuery(Guid Id) : IRequest<Inventory>;
    public class GetInevntoryById : IRequestHandler<GetInventoryByIdQuery, Inventory>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetInevntoryById(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Inventory> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _unitOfWork.Inventories.GetById(request.Id);

            if (inventory == null)
            {
                throw new Exception("Inventory not found");
            }
            return inventory;
        }
    }
}
