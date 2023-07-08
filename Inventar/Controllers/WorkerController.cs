using User.Models;
using User.Persistance;
using User.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : Controller
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var worker = await _workerService.Get();
            return worker;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var worker = await _workerService.GetById(id);
            return Ok(worker);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Worker worker)
        {
            var create = await _workerService.Create(worker);//Add Status Code Errors
            return Ok(create);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Worker worker)
        {

            try
            {
                var update = await _workerService.Update(worker);
                return update;
            }
            catch (Exception ex)
            {
                return NotFound($"Room not found");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var worker = await _workerService.Delete(id); //Add Status Code Errors,Fix to Delete all id-s to delete a table

            if (worker == null)
            {
                return NotFound($"Room with id:{id} not found");
            }

            return Ok($"Room with id:{id} deleted");


        }
    }
}
