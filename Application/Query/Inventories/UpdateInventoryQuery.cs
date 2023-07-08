using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventar.Models;
using MediatR;

namespace Application.Query.Inventories
{
    public class UpdateInventoryQuery : IRequest<Inventory>
    {
        public Inventory Inventory { get; }
       

        public UpdateInventoryQuery(Inventory inventory)
        {
            Inventory = inventory;
          
        }
    }
}
