using Inventar.Models;
using Inventar.Persistance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventar.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly DataContext _context;
        

        public WorkerService(DataContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Create(Worker worker)
        {
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();
            return new OkObjectResult(worker);

        }

        public async Task<Guid> Delete(Guid id)
        {
            var radnik = await _context.Workers.FindAsync(id);
            _context.Workers.Remove(radnik);
            await _context.SaveChangesAsync();
            return id;
        }

        public async Task<IActionResult> Get()
        {
            var radnici = await _context.Workers.ToListAsync();

            return new OkObjectResult(radnici);
        }

        public async Task<IActionResult> GetById(Guid id)
        {
            var worker = await _context.Workers.FindAsync(id);
            if (worker == null)
            {
                return new BadRequestObjectResult("Error");
            }
            return new OkObjectResult(worker);
        }

        public async Task<IActionResult> Update(Worker worker)
        {
            var existingWorker = await _context.Workers.FindAsync(worker.Id);

            if (existingWorker == null)
            {
                return new BadRequestObjectResult($"Room with id:{worker.Id} no found");
            }

            existingWorker.Name = worker.Name;
            existingWorker.PersonalNumber = worker.PersonalNumber;
            existingWorker.Surname = worker.Surname;
            existingWorker.Qualification = worker.Qualification;
            existingWorker.Gender = worker.Gender;
            existingWorker.RoomId = worker.RoomId;

            await _context.SaveChangesAsync();
            return new OkObjectResult(await _context.Rooms.ToListAsync());
        }
    }
}
