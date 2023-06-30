using Inventar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventar.Services
{
    public interface IRoomService
    {
        Task<IActionResult> Get();
        Task<IActionResult> GetById(Guid id);
        Task<IActionResult> Create(Room room);
        Task<IActionResult> Update(Room room);
        Task<Guid> Delete(Guid id);
    }
}
