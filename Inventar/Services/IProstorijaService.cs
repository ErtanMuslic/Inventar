using Inventar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventar.Services
{
    public interface IProstorijaService
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get(Guid id);
        Task<IActionResult> Create(Prostorija prostorija);
        Task<IActionResult> Update(Prostorija prostorija);
        Task<Guid> Delete(Guid id);
    }
}
