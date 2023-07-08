using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventar.Models;
using MediatR;

namespace Application.Query.Workers
{
    public class AddWorkerQuery : IRequest<Worker>
    {
        public Worker Worker { get; }

        public AddWorkerQuery(Worker worker) 
        {
            Worker = worker; 
        }
    }
}
