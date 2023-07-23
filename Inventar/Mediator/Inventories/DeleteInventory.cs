using Application.Query.Inventories;
using Infrastructure;
using MediatR;
using Inventar.Models;
using Inventar.Persistance;
using Microsoft.EntityFrameworkCore;

namespace API.Mediator.Inventories
{
    public record DeleteInventoryHandler(Guid Id): IRequest<Inventory>;
    public class DeleteInventory : IRequestHandler<DeleteInventoryHandler, Inventory>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteInventory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Inventory> Handle(DeleteInventoryHandler request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Inventories.GetById(request.Id);
            if (result == null)
            {
                throw new Exception("Inventory not found");
            }
            _unitOfWork.Inventories.Delete(result);
            _unitOfWork.Save();
            return result;
        }
    }
}
