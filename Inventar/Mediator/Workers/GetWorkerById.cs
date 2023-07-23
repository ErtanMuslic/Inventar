using Infrastructure;
using Inventar.Models;
using MediatR;

namespace API.Mediator.Workers
{
    public record GetWorkerByIdHandler(Guid Id) : IRequest<Worker>;
    public class GetWorkerById : IRequestHandler<GetWorkerByIdHandler, Worker>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetWorkerById(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Worker> Handle(GetWorkerByIdHandler request, CancellationToken cancellationToken)
        {
            var worker = await _unitOfWork.Workers.GetById(request.Id);
            if (worker == null)
            {
                throw new Exception("Worker not found");
            }
            return worker;
        }
    }
}
