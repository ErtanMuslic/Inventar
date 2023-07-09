using API.DTOs;
using Application.Query.Inventories;
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
    public class InventoryController : ControllerBase
    {
        private readonly ISender _mediator;


        public InventoryController(ISender mediator)
        {
            _mediator = mediator;
        }

        private readonly IMapper _mapper;
        public InventoryController(IMapper mapper)
        {
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var inventory = await _mediator.Send(new GetAllInventoriesQuery()); //Add Status Code Errors
            return Ok(inventory);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var inventory = await _mediator.Send(new GetInventoryByIdQuery(id));
            return Ok(inventory);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Inventory inventar)
        {
            var create = await _mediator.Send(new AddInventoryQuery(inventar));//Add Status Code Errors
            return create != null ? Created($"/inventory{create.Id}", create) : BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Inventory inventar)
        {
            var update = await _mediator.Send(new UpdateInventoryQuery(inventar));
            return update != null ? Ok(update) : BadRequest();
           
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(Guid id)
        {
            var inventory = await _mediator.Send(new DeleteInventoryQuery(id)); //Add Status Code Errors,Fix to Delete all id-s to delete a table

           return inventory != null ? Ok(inventory) : BadRequest();
        }


    }
}
