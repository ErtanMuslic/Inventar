using Inventar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventar.Services
{
    public interface IProstorijaService
    {
        List<Prostorija> Get();
        Prostorija Get(Guid id);
        Prostorija Create(Prostorija prostorija);
        void Update();
        void Delete(Prostorija prostorija);
    }
}
