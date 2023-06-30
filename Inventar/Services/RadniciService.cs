using Inventar.Models;
using Inventar.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventar.Services
{
    public class RadniciService : IRadniciService
    {
        private readonly DataContext _context;
        

        public RadniciService(DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Create(Radnici radnik)
        {
            _context.Radnicis.Add(radnik);
            await _context.SaveChangesAsync();
            return new OkObjectResult(radnik);

        }

        public async Task<Guid> Delete(Guid id)
        {
            var radnik = await _context.Radnicis.FindAsync(id);
            _context.Radnicis.Remove(radnik);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IActionResult> Get()
        {
            var radnici = await _context.Radnicis.ToListAsync();

            return new OkObjectResult(radnici);
        }

        public async Task<IActionResult> Get(Guid id)
        {
            var radnik = await _context.Radnicis.FindAsync(id);
            if (radnik == null)
            {
                return new BadRequestObjectResult("Error");
            }
            return new OkObjectResult(radnik);
        }

        public async Task<IActionResult> Update(Radnici radnik)
        {
            var existingRadnik = await _context.Radnicis.FindAsync(radnik.Id);

            if (existingRadnik == null)
            {
                return new BadRequestObjectResult($"Room with id:{radnik.Id} no found");
            }

            existingRadnik.Ime = radnik.Ime;
            existingRadnik.JMBG = radnik.JMBG;
            existingRadnik.Prezime = radnik.Prezime;
            existingRadnik.Sprema = radnik.Sprema;
            existingRadnik.Pol = radnik.Pol;
            existingRadnik.ProstorijaId = radnik.ProstorijaId;

            await _context.SaveChangesAsync();
            return new OkObjectResult(await _context.Radnicis.ToListAsync());
        }
    }
}
