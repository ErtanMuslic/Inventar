using User.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

