//using Inventar.Models;
//using Inventar.Persistance;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
////using MongoDB.Driver;

//namespace Inventar.Services
//{
//    public class ProstorijaService : IProstorijaService
//    {
//        //private readonly IMongoCollection<Prostorija> _premises;
//        private readonly DataContext _context;


//        public ProstorijaService(DataContext context)
//        {
//            _context = context;
//        }
//        //public ProstorijaService(IInventarDatabaseSettings settings,IMongoClient mongoClient) 
//        //{
//        //    var database = mongoClient.GetDatabase(settings.DatabaseName);
//        //    _premises = database.GetCollection<Prostorija>(settings.InventarCollectionName);
//        //}

//        public Prostorija Create(Prostorija prostorija)
//        {
//            _context.Add(prostorija);
//            return prostorija;
            
//        }

//        public void Delete(Prostorija prostorija)
//        {
//            _context.Prostorijas.Remove(prostorija); 
//        }

//        public async Task<ActionResult<List<Prostorija>>> Get()
//        {
//            return await _context.Prostorijas.ToListAsync();
//        }

//        public Prostorija Get(Guid id)
//        {
//            return  _context.Prostorijas.Find(id);
//        }

//        public void Update()
//        {
//            _context.SaveChangesAsync();
//        }
//    }
//}
