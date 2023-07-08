using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventar.Models;

namespace Application.Query.Inventories
{
    public class DeleteInventoryQuery : IRequest<Inventory>
    {
        
            public Guid Id { get; }

            public DeleteInventoryQuery(Guid id)
            {
                Id = id;
            }
        }
    }

