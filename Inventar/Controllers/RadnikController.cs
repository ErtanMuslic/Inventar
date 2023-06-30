using Inventar.Models;
using Inventar.Persistance;
using Inventar.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RadnikController : Controller
    {
        private readonly IRadniciService _radniciService;

        public RadnikController(IRadniciService radniciService)
        {
            _radniciService = radniciService;
        }



        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var radnici = await _radniciService.Get();
            return radnici;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var prostorija = await _radniciService.Get(id);
            return Ok(prostorija);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Radnici radnik)
        {
            var create = await _radniciService.Create(radnik);//Add Status Code Errors
            return Ok(create);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Radnici radnik)
        {

            try
            {
                var update = await _radniciService.Update(radnik);
                return update;
            }
            catch (Exception ex)
            {
                return NotFound($"Room not found");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var prostorija = await _radniciService.Delete(id); //Add Status Code Errors,Fix to Delete all id-s to delete a table

            if (prostorija == null)
            {
                return NotFound($"Room with id:{id} not found");
            }

            return Ok($"Room with id:{id} deleted");


        }
    }
}
