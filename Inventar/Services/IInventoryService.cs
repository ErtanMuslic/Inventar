using Inventar.Models;
using Microsoft.AspNetCore.Mvc;


namespace Inventar.Services
{
    public interface IInventoryService
    {
        Task<IActionResult> Get();
        Task<IActionResult> GetById(Guid id);
        Task<IActionResult> Create(Inventory inventari);
        Task<IActionResult> Update(Inventory inventari);
        Task<Guid> Delete(Guid id);
    }
}
