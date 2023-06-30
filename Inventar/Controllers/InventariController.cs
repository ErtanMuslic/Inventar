using Inventar.Models;
using Inventar.Persistance;
using Inventar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventariController : ControllerBase
    {
        private readonly IInventariService _inventariService;


        public InventariController(IInventariService inventariService)
        {
            _inventariService = inventariService;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var inventari = await _inventariService.Get(); //Add Status Code Errors
            return Ok(inventari);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var inventari = await _inventariService.Get(id);
            return Ok(inventari);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Inventari inventar)
        {
            var create = await _inventariService.Create(inventar);//Add Status Code Errors
            return create;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Inventari inventar)
        {

            try
            {
                var update = await _inventariService.Update(inventar);
                return update;
            }
            catch (Exception ex)
            {
                return NotFound($"Inventar not found");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var inventar = await _inventariService.Delete(id); //Add Status Code Errors,Fix to Delete all id-s to delete a table
            //var prostorija = await _context.Prostorijas.FindAsync(id);

            if (inventar == null)
            {
                return NotFound($"Inventar with id:{id} not found");
            }

            //_context.Prostorijas.Remove(prostorija);
            //await _context.SaveChangesAsync();
            return Ok($"Inventar with id:{id} deleted");


        }


    }
}
