using Inventar.Models;
using Inventar.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
//using MongoDB.Driver;

namespace Inventar.Services
{
    public class ProstorijaService : IProstorijaService
    {
        private readonly DataContext _context;


        public ProstorijaService(DataContext context)
        {
            _context = context;
        }
        

        public async Task<Prostorija> Create(Prostorija prostorija)
        {
            _context.Add(prostorija);
            await _context.SaveChangesAsync();
            return prostorija;
            
        }

        public async Task<Guid> Delete(Guid id)
        {
            var prostorija = await _context.Prostorijas.FindAsync(id);
            _context.Prostorijas.Remove(prostorija); 
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<ActionResult<List<Prostorija>>> Get()
        {
            var prostorije = await _context.Prostorijas.ToListAsync();
            return prostorije;
        }

        public async  Task<ActionResult<Prostorija>> Get(Guid id)
        {
            var prostorija = await _context.Prostorijas.FindAsync(id);
            return prostorija;
        }

        public async Task<IActionResult> Update(Prostorija prostorija)
        {
            var existingProstorija = await _context.Prostorijas.FindAsync(prostorija.Id);

            if (existingProstorija == null)
            {
                return new BadRequestObjectResult($"Room with id:{prostorija.Id} no found");
            }

            existingProstorija.Naziv = prostorija.Naziv;
            existingProstorija.Sirina = prostorija.Sirina;
            existingProstorija.Duzina = prostorija.Duzina;
            existingProstorija.Sprat = prostorija.Sprat;
            existingProstorija.Visina = prostorija.Visina;

            await _context.SaveChangesAsync();
            return new OkObjectResult(await _context.Prostorijas.ToListAsync());
        }
    }
}
