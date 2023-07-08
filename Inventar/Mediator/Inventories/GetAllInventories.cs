using Application.Query.Inventories;
using Infrastructure;
using User.Models;
using MediatR;

namespace API.Mediator.Inventories
{
    public class GetAllInventories : IRequestHandler<GetAllInventoriesQuery, List<Inventory>>
    {

        private readonly IUnitOfWork _unitOfWork;

        public GetAllInventories(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<List<Inventory>> Handle(GetAllInventoriesQuery request, CancellationToken cancellationToken)
        {
            var invenotries = await _unitOfWork.Inventories.GetAll();
                return invenotries;
        }
    }
}
