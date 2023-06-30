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
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventoryService;


        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var inventory = await _inventoryService.Get(); //Add Status Code Errors
            return Ok(inventory);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var inventory = await _inventoryService.GetById(id);
            return Ok(inventory);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Inventory inventar)
        {
            var create = await _inventoryService.Create(inventar);//Add Status Code Errors
            return create;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Inventory inventar)
        {

            try
            {
                var update = await _inventoryService.Update(inventar);
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
            var inventory = await _inventoryService.Delete(id); //Add Status Code Errors,Fix to Delete all id-s to delete a table
            //var prostorija = await _context.Prostorijas.FindAsync(id);

            if (inventory == null)
            {
                return NotFound($"Inventar with id:{id} not found");
            }

            //_context.Prostorijas.Remove(prostorija);
            //await _context.SaveChangesAsync();
            return Ok($"Inventar with id:{id} deleted");


        }


    }
}
