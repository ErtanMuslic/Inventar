using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventar.Models;
using MediatR;

namespace Application.Query.Workers
{
    public class GetWorkerByIdQuery : IRequest<Worker>
    {
        public Guid Id { get; }

        public GetWorkerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
