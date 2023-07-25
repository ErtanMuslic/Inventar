using System.Data;
using API.DTOs;
using API.Mediator.Rooms;
using Application.Query.Rooms;
using AutoMapper;
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
        private readonly IMapper _mapper;
        private readonly ILogger<RoomController> _logger;
        public RoomController(ISender mediator,IMapper mapper,ILogger<RoomController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }

    
        [HttpGet]
        public async Task<IActionResult> GetRoomList()
        {
            _logger.LogInformation("Get All Rooms");

            var rooms = await _mediator.Send(new GetAllRoomsHandler());
            return rooms != null ? Ok(rooms) : BadRequest();
        }

        
        [HttpGet("{roomId}")]
        public async Task<IActionResult> GetRoomById(Guid roomId)
        {
            _logger.LogInformation("Get Room By Id");

            var room = await _mediator.Send(new GetRoomByIdHandler(roomId));
            return room != null ? Ok(_mapper.Map<RoomDto>(room)) : BadRequest();
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateRoom(RoomDto roomDetails)
        {
            _logger.LogInformation("Create Room");

            var room = await _mediator.Send(new AddRoomHandler(roomDetails));
            return room != null ? Created($"/room/{room.Name}", room) : BadRequest();
        }
      

        [HttpDelete("{roomId}")]
        public async Task<IActionResult> DeleteRoom(Guid roomId)
        {
            _logger.LogInformation("Delete Room");

            var room = await _mediator.Send(new DeleteRoomHandler(roomId));
            return room != null ? Ok(_mapper.Map<RoomDto>(room)) : BadRequest();
        }
    }
}

