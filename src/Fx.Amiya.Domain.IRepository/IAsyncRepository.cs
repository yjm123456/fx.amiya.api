using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fx.Amiya.Domain.IRepository
{
    public interface IAsyncRepository<T, TId> 
    {
        Task<T> GetByIdAsync(TId id);

        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
