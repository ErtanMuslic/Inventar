using System.Linq;
using API.DTOs;
using API.Mediator.Inventories;
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
        private readonly ILogger<InventoryController> _logger;


        public InventoryController(ISender mediator, IMapper mapper, ILogger<InventoryController> logger)
        {
            _mediator = mediator;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get all Inventories");

            var inventory = await _mediator.Send(new GetAllInventoriesQuery());
            return inventory != null ? Ok(inventory) : BadRequest();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            _logger.LogInformation("Get Inventory by Id");

             var inventory = await _mediator.Send(new GetInventoryByIdQuery(id));
            return inventory != null ? Ok(_mapper.Map<InventoryDto>(inventory)) : BadRequest();        
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InventoryDto inventar)
        {
            _logger.LogInformation("Create Inventory");

            var create = await _mediator.Send(new AddInventoryHandler(inventar));
            return create != null ? Created($"/inventory{create.Name}", create) : BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Inventory inventar)
        {
            _logger.LogInformation("Update Inventory");

            var update = await _mediator.Send(new UpdateInevntoryQuery(inventar));
            return update != null ? Ok(_mapper.Map<InventoryDto>(update)) : BadRequest();     
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(Guid id)
        {
            _logger.LogInformation("Delete Inventory");

            var inventory = await _mediator.Send(new DeleteInventoryQuery(id)); 
           return inventory != null ? Ok(_mapper.Map<InventoryDto>(inventory)) : BadRequest();
        }
    }
}
