using Inventar.Models;
using Inventar.Persistance;
using Inventar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var room = await _roomService.Get(); //Add Status Code Errors
            return Ok(room);
            
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var room = await _roomService.GetById(id);
             return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Room room)
        {
                var create = await _roomService.Create(room);//Add Status Code Errors
                return create;              
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Room room)
        {
            
            try
            {
                var update = await _roomService.Update(room);
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
                var room = await _roomService.Delete(id); //Add Status Code Errors,Fix to Delete all id-s to delete a table

            if (room == null)
            {
                return NotFound($"Room with id:{id} not found");
            }

              return Ok($"Room with id:{id} deleted");

           
        }

       
    }
}
