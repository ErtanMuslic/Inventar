using Application.Query.Workers;
using Infrastructure;
using Inventar.Models;
using MediatR;

namespace API.Mediator.Workers
{
    public class DeleteWorker : IRequestHandler<DeleteWorkerQuery, Worker>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteWorker(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Worker> Handle(DeleteWorkerQuery request, CancellationToken cancellationToken)
        {
            var worker = await _unitOfWork.Workers.GetById(request.Id);
            if (worker == null)
            {

            }
            _unitOfWork.Workers.Delete(worker);
            _unitOfWork.Save();
            return worker;
        }
    }
}
