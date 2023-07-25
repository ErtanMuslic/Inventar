using API.DTOs;
using API.Mediator.Workers;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : Controller
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        private readonly ILogger<WorkerController> _logger;

        public WorkerController(ISender mediator, IMapper mapper, ILogger<WorkerController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get All Workers");

            var worker = await _mediator.Send(new GetAllWorkersHandler());
            return worker != null ? Ok(worker) : BadRequest();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation("Get Worker By Id");

            var worker = await _mediator.Send(new GetWorkerByIdHandler(id));
            return worker != null ? Ok(_mapper.Map<WorkerDto>(worker)) : BadRequest();
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WorkerDto worker)
        {
            _logger.LogInformation("Hire Worker");

            var create = await _mediator.Send(new AddWorkerHandler(worker));
            return create != null ? Created($"/room/{create.Name}", create) : BadRequest();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            _logger.LogInformation("Fire Worker");

            var worker = await _mediator.Send(new DeleteWorkerHandler(id)); 
            return worker != null ? Ok(_mapper.Map<WorkerDto>(worker)) : NotFound();
        }
    }
}
