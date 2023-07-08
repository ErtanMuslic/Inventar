﻿using Application.Query.Inventories;
using Infrastructure;
using User.Models;
using MediatR;

namespace API.Mediator.Inventories
{
    public class AddInventory : IRequestHandler<AddInventoryQuery, Inventory>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddInventory(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Inventory> Handle(AddInventoryQuery request, CancellationToken cancellationToken)
        {
           var inventories = await _unitOfWork.Inventories.Add(request.Inventory);
            return inventories;
        }
    }
}