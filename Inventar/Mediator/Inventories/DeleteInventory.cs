using Application.Query.Inventories;
using Infrastructure;
using MediatR;
using Inventar.Models;

namespace API.Mediator.Inventories
{
    public class DeleteInventory : IRequestHandler<DeleteInventoryQuery, Inventory>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteInventory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Inventory> Handle(DeleteInventoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Inventories.GetById(request.Id);
            if (result == null)
            {

            }
            _unitOfWork.Inventories.Delete(result);
            _unitOfWork.Save();
            return result;
        }
    }
}
