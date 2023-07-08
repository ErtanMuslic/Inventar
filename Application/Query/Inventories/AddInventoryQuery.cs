﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventar.Models;

namespace Application.Query.Inventories
{
    public class AddInventoryQuery : IRequest<Inventory>
    {
        public Inventory Inventory { get;  }

        public AddInventoryQuery(Inventory inventory) 
        { 
            Inventory = inventory;
        }
    }
}
