using Infrastructure;
using MediatR;
using Inventar.Models;

namespace API.Mediator.Inventories
{
    public record GetInventoryByIdHandler(Guid Id) : IRequest<Inventory>;
    public class GetInevntoryById : IRequestHandler<GetInventoryByIdHandler, Inventory>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetInevntoryById(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Inventory> Handle(GetInventoryByIdHandler request, CancellationToken cancellationToken)
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
