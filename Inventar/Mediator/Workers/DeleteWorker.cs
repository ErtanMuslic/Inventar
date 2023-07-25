using Application.Query.Workers;
using Infrastructure;
using Inventar.Models;
using MediatR;

namespace API.Mediator.Workers
{
    public record DeleteWorkerHandler(Guid Id) : IRequest<Worker>;
    public class DeleteWorker : IRequestHandler<DeleteWorkerHandler, Worker>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteWorker(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Worker> Handle(DeleteWorkerHandler request, CancellationToken cancellationToken)
        {
            var worker = await _unitOfWork.Workers.GetById(request.Id);
            if (worker == null)
            {
                throw new Exception("Worker not found");
            }
            _unitOfWork.Workers.Delete(worker);
            _unitOfWork.Save();
            return worker;
        }
    }
}
