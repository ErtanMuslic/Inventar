﻿using User.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Query.Inventories
{
    public class GetInventoryByIdQuery : IRequest<Inventory>
    {
        public Guid Id { get;  }

        public GetInventoryByIdQuery(Guid id)
        {
                Id = id;
        }
    }
}
