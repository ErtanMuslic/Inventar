using API.DTOs;
using Application.Query.Workers;
using AutoMapper;
using Infrastructure;
using Inventar.Models;
using MediatR;

namespace API.Mediator.Workers
{
    public record GetAllWorkersHandler() : IRequest<IEnumerable<WorkerDto>>;
    public class GetAllWorkers : IRequestHandler<GetAllWorkersHandler, IEnumerable<WorkerDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllWorkers(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<WorkerDto>> Handle(GetAllWorkersHandler request, CancellationToken cancellationToken)
        {
            var worker = await _unitOfWork.Workers.GetAll();
            var result = worker.Select(w => _mapper.Map<WorkerDto>(w));
            return result;
        }
    }
}
