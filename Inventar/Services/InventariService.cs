using Inventar.Models;
using Inventar.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Inventar.Services
{
    public class InventariService : IInventariService
    {
        private readonly DataContext _context;


        public InventariService(DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Create(Inventari inventari)
        {
            _context.Add(inventari);
            await _context.SaveChangesAsync();
            return new OkObjectResult(inventari);

        }

        public async Task<Guid> Delete(Guid id)
        {
            var inventari = await _context.Inventars.FindAsync(id);
            _context.Inventars.Remove(inventari);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IActionResult> Get()
        {
            var inventari = await _context.Inventars.ToListAsync();

            return new OkObjectResult(inventari);
        }

        public async Task<IActionResult> Get(Guid id)
        {
            var inventari = await _context.Inventars.FindAsync(id);
            if (inventari == null)
            {
                return new BadRequestObjectResult("Error");
            }
            return new OkObjectResult(inventari);
        }

        public async Task<IActionResult> Update(Inventari inventari)
        {
            var existingInventari = await _context.Inventars.FindAsync(inventari.Id);

            if (existingInventari == null)
            {
                return new BadRequestObjectResult($"Room with id:{inventari.Id} no found");
            }

            existingInventari.Naziv = inventari.Naziv;
            existingInventari.SerijskiBroj = inventari.SerijskiBroj;
            existingInventari.Marka = inventari.Marka;
            existingInventari.Model = inventari.Model;
            existingInventari.Cena = inventari.Cena;

            await _context.SaveChangesAsync();
            return new OkObjectResult(await _context.Inventars.ToListAsync());
        }
    }
}
    

