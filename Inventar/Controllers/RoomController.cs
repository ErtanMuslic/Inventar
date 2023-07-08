using System.Data;
using Application.Query.Rooms;
using Inventar.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Inventar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly ISender _mediator;
        public RoomController(ISender mediator)
        {
            _mediator = mediator;
        }

    
        [HttpGet]
        public async Task<IActionResult> GetRoomList()
        {
            var rooms = await _mediator.Send(new GetAllRoomsQuery());
            return Ok(rooms);
           
        }

        
        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetRoomById(Guid roomId)
        {
            var room = await _mediator.Send(new GetRoomByIdQuery(roomId));
            return room != null ? Ok(room) : NotFound();

        }

       
        [HttpPost]
        public async Task<IActionResult> CreateRoom(Room roomDetails)
        {
            var room = await _mediator.Send(new AddRoomQuery(roomDetails));
            return room != null ? Created($"/room/{room.Id}", room) : BadRequest();
           
        }

       
        //[HttpPut]
        //public async Task<IActionResult> UpdateProduct(Room roomDetails)
        //{
        //    if (roomDetails != null)
        //    {
        //        var isCreated = await _roomService.UpdateProduct(roomDetails);
        //        if (isCreated)
        //        {
        //            return Ok(isCreated);
        //        }
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        
        [HttpDelete("{roomId}")]
        public async Task<IActionResult> DeleteRoom(Guid roomId)
        {
            var room = await _mediator.Send(new DeleteRoomQuery(roomId));
            return room != null ? Ok(room) : NotFound();
            
        }
    }
}

