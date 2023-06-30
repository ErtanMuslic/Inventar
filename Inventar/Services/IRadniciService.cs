using Inventar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventar.Services
{
    public interface IRadniciService
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get(Guid id);
        Task<IActionResult> Create(Radnici radnik);
        Task<IActionResult> Update(Radnici radnik);
        Task<Guid> Delete(Guid id);
    }
}
