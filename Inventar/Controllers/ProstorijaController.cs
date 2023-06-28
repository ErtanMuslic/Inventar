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
    public class ProstorijaController : ControllerBase
    {
        private readonly IProstorijaService _prostorijaService;
        

        public ProstorijaController(IProstorijaService prostorijaService)
        {
           _prostorijaService = prostorijaService;
        }
        


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var prostorije = await _prostorijaService.Get(); //Add Status Code Errors
            return Ok(prostorije);
            
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var prostorija = await _prostorijaService.Get(id);
             return Ok(prostorija);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Prostorija prostorija)
        {
                var create = await _prostorijaService.Create(prostorija);//Add Status Code Errors
                return create;              
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Prostorija prostorija)
        {
            
            try
            {
                var update = await _prostorijaService.Update(prostorija);
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
                var prostorija = await _prostorijaService.Delete(id); //Add Status Code Errors,Fix to Delete all id-s to delete a table
            //var prostorija = await _context.Prostorijas.FindAsync(id);

            if (prostorija == null)
            {
                return NotFound($"Room with id:{id} not found");
            }

              //_context.Prostorijas.Remove(prostorija);
              //await _context.SaveChangesAsync();
              return Ok($"Room with id:{id} deleted");

           
        }

       
    }
}
