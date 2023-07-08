using Application.Query.Inventories;
using Infrastructure;
using Inventar.Models;
using MediatR;

namespace API.Mediator.Inventories
{
    public class UpdateInventory : IRequestHandler<UpdateInventoryQuery,Inventory>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateInventory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Inventory> Handle(UpdateInventoryQuery request, CancellationToken cancellationToken)
        {
            var inventory = await _unitOfWork.Inventories.GetById(request.Inventory.Id);
            if (inventory == null)
            {

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
