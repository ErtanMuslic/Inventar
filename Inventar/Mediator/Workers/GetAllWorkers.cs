using Application.Query.Workers;
using Infrastructure;
using Inventar.Models;
using MediatR;

namespace API.Mediator.Workers
{
    public class GetAllWorkers : IRequestHandler<GetAllWorkersQuery, List<Worker>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllWorkers(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Worker>> Handle(GetAllWorkersQuery request, CancellationToken cancellationToken)
        {
            var worker = await _unitOfWork.Workers.GetAll();
            return worker;
        }
    }
}
