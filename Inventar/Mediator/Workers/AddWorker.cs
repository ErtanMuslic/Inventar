using API.DTOs;
using Application.Query.Workers;
using AutoMapper;
using Infrastructure;
using Inventar.Models;
using MediatR;

namespace API.Mediator.Workers
{
    public record AddWorkerHandler(WorkerDto workerDto): IRequest<WorkerDto>;
    public class AddWorker : IRequestHandler<AddWorkerHandler, WorkerDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddWorker(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<WorkerDto> Handle(AddWorkerHandler request, CancellationToken cancellationToken)
        {
            request.workerDto.Qualification = "Worker";
            var newWorker = _mapper.Map<Worker>(request.workerDto);
            var result = await _unitOfWork.Workers.Add(newWorker);
            _unitOfWork.Save();
            return _mapper.Map<WorkerDto>(newWorker);
            
        }
    }
}
