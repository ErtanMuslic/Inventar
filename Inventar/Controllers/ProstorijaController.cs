using Inventar.Models;
using Inventar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProstorijaController : ControllerBase
    {
        private readonly IProstorijaService prostorijaService;

        public ProstorijaController(IProstorijaService prostorijaService) {
            this.prostorijaService = prostorijaService;
        }


        [HttpGet]
        public ActionResult<List<Prostorija>> Get()
        {
            return prostorijaService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Prostorija> Get(string id)
        {
            var prostorija = prostorijaService.Get(id);

            if(prostorija == null)
            {
                return NotFound($"Room with Id = {id} not found");
            }

            return prostorija;
        }

        [HttpPost]
        public ActionResult<Prostorija> Create([FromBody] Prostorija prostorija)
        {
            prostorijaService.Create(prostorija);
            return CreatedAtAction(nameof(Get),new {id = prostorija.Id},prostorija);
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Prostorija prostorija)
        {
            var existingProstorija = prostorijaService.Get(id);

            if(existingProstorija == null)
            {
                return NotFound($"Room with id:{id} no found");
            }

            prostorijaService.Update(id, prostorija);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var prostorija = prostorijaService.Get(id);

            if(prostorija == null)
            {
                return NotFound($"Room with id:{id} not found");
            }

            prostorijaService.Delete(prostorija.Id);

            return Ok($"Room with id:{id} deleted");
           
        }

       
    }
}
