﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User.Models;

namespace Application.Query.Users
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
