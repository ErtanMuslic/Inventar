using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventar.Models;
using MediatR;

namespace Application.Query.Rooms
{
    public class AddRoomQuery : IRequest<Room>
    {
        public Room Room { get; }
       
        public AddRoomQuery(Room room)
        {
            Room = room;
        }

       
    }
}
