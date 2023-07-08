using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces.Base
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        Task<T> Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
