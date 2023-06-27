using Inventar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventar.Services
{
    public interface IProstorijaService
    {
        Task<ActionResult<List<Prostorija>>> Get();
        Task<ActionResult<Prostorija>> Get(Guid id);
        Task<Prostorija> Create(Prostorija prostorija);
        Task<IActionResult> Update(Prostorija prostorija);
        Task<Guid> Delete(Guid id);
    }
}
