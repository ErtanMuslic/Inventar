using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces.Base;
using Infrastructure.Repositories.Base;
using Inventar.Models;

namespace Infrastructure.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {

    }
}
