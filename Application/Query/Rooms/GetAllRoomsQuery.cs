﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Models;
using MediatR;

namespace Application.Query.Rooms
{
    public class GetAllRoomsQuery : IRequest<List<Room>>
    {

    }
}