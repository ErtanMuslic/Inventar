using API.Mediator.Workers;
using Application.Query.Workers;
using Inventar.Models;
using Inventar.Persistance;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : Controller
    {
        private readonly ISender _mediator;

        public WorkerController(ISender mediator)
        {
            _mediator = mediator;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var worker = await _mediator.Send(new GetAllWorkersQuery());
            return Ok(worker);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var worker = await _mediator.Send(new GetWorkerByIdQuery(id));
            return worker != null ? Ok(worker) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Worker worker)
        {
            var create = await _mediator.Send(new AddWorkerQuery(worker));
            return create != null ? Created($"/room/{create.Id}", create) : BadRequest();
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put([FromBody] Worker worker)
        //{

        //    try
        //    {
        //        var update = await _workerService.Update(worker);
        //        return update;
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound($"Room not found");
        //    }
        //}


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var worker = await _mediator.Send(new DeleteWorkerQuery(id)); //Add Status Code Errors,Fix to Delete all id-s to delete a table
            return worker != null ? Ok(worker) : NotFound();
            


        }
    }
}
