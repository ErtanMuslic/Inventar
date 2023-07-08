using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Inventar.Models;

namespace Application.Query.Rooms
{
    public class GetAllRoomsQuery : IRequest<List<Room>>
    {

    }
}
