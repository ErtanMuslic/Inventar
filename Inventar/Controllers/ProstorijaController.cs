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
        private readonly DataContext _context;


        public ProstorijaController(DataContext context) {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<Prostorija>>> Get()
        {
            return Ok(await _context.Prostorijas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prostorija>> Get(string id)
        {
            var prostorija = await _context.Prostorijas.FindAsync(id);

            if(prostorija == null)
            {
                return NotFound($"Room with Id = {id} not found");
            }

            return prostorija;
        }

        [HttpPost]
        public async Task<ActionResult<Prostorija>> Create([FromBody] Prostorija prostorija)
        {
            _context.Add(prostorija);
            await _context.SaveChangesAsync();
            return Ok(await _context.Prostorijas.ToListAsync());
            //return CreatedAtAction(nameof(Get),new {id = prostorija.Id},prostorija);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] Prostorija prostorija)
        {
            var existingProstorija = await _context.Prostorijas.FindAsync(prostorija.Id);

            if(existingProstorija == null)
            {
                return NotFound($"Room with id:{prostorija.Id} no found");
            }

            existingProstorija.Naziv = prostorija.Naziv;
            existingProstorija.Sirina = prostorija.Sirina;
            existingProstorija.Duzina = prostorija.Duzina;
            existingProstorija.Sprat=prostorija.Sprat;
            existingProstorija.Visina = prostorija.Visina;

            await _context.SaveChangesAsync();
            return Ok(await _context.Prostorijas.ToListAsync());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            var prostorija = await _context.Prostorijas.FindAsync(id);

            if(prostorija == null)
            {
                return NotFound($"Room with id:{id} not found");
            }

            _context.Prostorijas.Remove(prostorija);
            await _context.SaveChangesAsync();
            return Ok($"Room with id:{id} deleted");
           
        }

       
    }
}
