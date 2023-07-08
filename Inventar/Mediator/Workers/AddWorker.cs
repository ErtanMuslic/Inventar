using Application.Query.Workers;
using Infrastructure;
using Inventar.Models;
using MediatR;

namespace API.Mediator.Workers
{
    public class AddWorker : IRequestHandler<AddWorkerQuery, Worker>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddWorker(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Worker> Handle(AddWorkerQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Workers.Add(request.Worker);
            _unitOfWork.Save();
            return result;
        }
    }
}
