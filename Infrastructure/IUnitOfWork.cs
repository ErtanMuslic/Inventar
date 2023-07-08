using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces;

namespace Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IRoomRepository Rooms { get; }
        int Save();
        
    }
}
