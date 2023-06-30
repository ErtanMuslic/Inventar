using Inventar.Models;
using Inventar.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Inventar.Services
{
    public class RoomService : IRoomService
    {
        private readonly DataContext _context;


        public RoomService(DataContext context)
        {
            _context = context;
        }
        

        public async Task<IActionResult> Create(Room room)
        {
            _context.Add(room);
            await _context.SaveChangesAsync();
            return new OkObjectResult(room);
            
        }

        public async Task<Guid> Delete(Guid id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room); 
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IActionResult> Get()
        {
            var room = await _context.Rooms.ToListAsync();
            
            return new OkObjectResult(room);
        }

        public async  Task<IActionResult> GetById(Guid id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return new BadRequestObjectResult("Error");
            }
            return new OkObjectResult(room);
        }

        public async Task<IActionResult> Update(Room room)
        {
            var existingroom = await _context.Rooms.FindAsync(room.Id);

            if (existingroom == null)
            {
                return new BadRequestObjectResult($"Room with id:{room.Id} no found");
            }

            existingroom.Name = room.Name;
            existingroom.Width = room.Width;
            existingroom.Lenght = room.Lenght;
            existingroom.Floor = room.Floor;
            existingroom.Height = room.Height;

            await _context.SaveChangesAsync();
            return new OkObjectResult(await _context.Rooms.ToListAsync());
        }
    }
}
