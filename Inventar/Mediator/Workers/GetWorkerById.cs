using Application.Query.Workers;
using Infrastructure;
using Inventar.Models;
using MediatR;

namespace API.Mediator.Workers
{
    public class GetWorkerById : IRequestHandler<GetWorkerByIdQuery, Worker>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetWorkerById(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Worker> Handle(GetWorkerByIdQuery request, CancellationToken cancellationToken)
        {
            var worker = await _unitOfWork.Workers.GetById(request.Id);
            return worker;
        }
    }
}
