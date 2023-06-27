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
            var prostorije = await _prostorijaService.Get();
            return Ok(prostorije);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var prostorija = await _prostorijaService.Get(id);

            if(prostorija == null)
            {
                return NotFound($"Room with Id = {id} not found");
            }

            return Ok(prostorija);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Prostorija prostorija)
        { 
            _prostorijaService.Create(prostorija);
            return Ok(prostorija);
            //_context.Add(prostorija);
            //await _context.SaveChangesAsync();
            //return Ok(await _context.Prostorijas.ToListAsync());
            //return CreatedAtAction(nameof(Get),new {id = prostorija.Id},prostorija);
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
            var prostorija = await _prostorijaService.Delete(id);
            //var prostorija = await _prostorijaService.Get(id);

            if(prostorija == null)
            {
                return NotFound($"Room with id:{id} not found");
            }

            //_context.Prostorijas.Remove(prostorija);
            //await _context.SaveChangesAsync();
            return Ok($"Room with id:{id} deleted");
           
        }

       
    }
}
