using Inventar.Models;
using Inventar.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Inventar.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly DataContext _context;


        public InventoryService(DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Create(Inventory inventory)
        {
            _context.Add(inventory);
            await _context.SaveChangesAsync();
            return new OkObjectResult(inventory);

        }

        public async Task<Guid> Delete(Guid id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            _context.Inventory.Remove(inventory);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IActionResult> Get()
        {
            var inventory = await _context.Inventory.ToListAsync();

            return new OkObjectResult(inventory);
        }

        public async Task<IActionResult> GetById(Guid id)
        {
            var inventory = await _context.Inventory.FindAsync(id);
            if (inventory == null)
            {
                return new BadRequestObjectResult("Error");
            }
            return new OkObjectResult(inventory);
        }

        public async Task<IActionResult> Update(Inventory inventory)
        {
            var existingInventory = await _context.Inventory.FindAsync(inventory.Id);

            if (existingInventory == null)
            {
                return new BadRequestObjectResult($"Room with id:{inventory.Id} no found");
            }

            existingInventory.Name = inventory.Name;
            existingInventory.SerialNumber = inventory.SerialNumber;
            existingInventory.Mark = inventory.Mark;
            existingInventory.Model = inventory.Model;
            existingInventory.Price = inventory.Price;
            existingInventory.RoomId = inventory.RoomId;

            await _context.SaveChangesAsync();
            return new OkObjectResult(await _context.Inventory.ToListAsync());
        }
    }
}
    

