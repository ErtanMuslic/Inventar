using Inventar.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Inventar.Services
{
    public class ProstorijaService : IProstorijaService
    {
        private readonly IMongoCollection<Prostorija> _premises;

        public ProstorijaService(IInventarDatabaseSettings settings,IMongoClient mongoClient) 
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _premises = database.GetCollection<Prostorija>(settings.InventarCollectionName);
        }

        public Prostorija Create(Prostorija prostorija)
        {
           _premises.InsertOne(prostorija);
            return prostorija;
        }

        public void Delete(string id)
        {
            _premises.DeleteOne(prostorija => prostorija.Id == id);
        }

        public List<Prostorija> Get()
        {
           return _premises.Find(prostorija => true).ToList();
        }

        public Prostorija Get(string id)
        {
            return _premises.Find(prostorija => prostorija.Id == id).FirstOrDefault();
        }

        public void Update(string id, Prostorija prostorija)
        {
            _premises.ReplaceOne(prostorija => prostorija.Id == id,prostorija);
        }
    }
}
