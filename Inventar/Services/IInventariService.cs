using Inventar.Models;
using Microsoft.AspNetCore.Mvc;


namespace Inventar.Services
{
    public interface IInventariService
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get(Guid id);
        Task<IActionResult> Create(Inventari inventari);
        Task<IActionResult> Update(Inventari inventari);
        Task<Guid> Delete(Guid id);
    }
}
