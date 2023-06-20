using Inventar.Models;

namespace Inventar.Services
{
    public interface IProstorijaService
    {
        List<Prostorija> Get();
        Prostorija Get(string id);
        Prostorija Create(Prostorija prostorija);
        void Update(string id,Prostorija prostorija);
        void Delete(string id);
    }
}
