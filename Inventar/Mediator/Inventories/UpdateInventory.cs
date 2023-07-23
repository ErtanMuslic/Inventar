using Application.Query.Inventories;
using Infrastructure;
using Inventar.Models;
using MediatR;

namespace API.Mediator.Inventories
{
    public record UpdateInevntoryHandler(Inventory Inventory): IRequest<Inventory>;
    public class UpdateInventory : IRequestHandler<UpdateInevntoryHandler, Inventory>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateInventory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Inventory> Handle(UpdateInevntoryHandler request, CancellationToken cancellationToken)
        {
            var inventory = await _unitOfWork.Inventories.GetById(request.Inventory.Id);
            if (inventory == null)
            {
                throw new Exception("Inventory not found");
            }

            inventory.Name = request.Inventory.Name;
            inventory.SerialNumber = request.Inventory.SerialNumber;
            inventory.Mark = request.Inventory.Mark;
            inventory.Model = request.Inventory.Model;
            inventory.Price = request.Inventory.Price;
            _unitOfWork.Save();
            return inventory;
        }
    }
}
