using System.Linq;
using API.DTOs;
using API.Mediator.Inventories;
using Application.Query.Inventories;
using AutoMapper;
using Inventar.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nest;

namespace Inventar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;


        public InventoryController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var inventory = await _mediator.Send(new API.Mediator.Inventories.GetAllInventoriesQuery()); //Add Status Code Errors
            return Ok(inventory);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var inventory = await _mediator.Send(new API.Mediator.Inventories.GetInventoryByIdQuery(id));
            return Ok(_mapper.Map<InventoryDto>(inventory));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryDto inventar)
        {

            var create = await _mediator.Send(new AddInventoryHandler(inventar));//Add Status Code Errors

            return create != null ? Created($"/inventory{create.Name}", create) : BadRequest();
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
