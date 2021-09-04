using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrushItem.Respository
{
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> SaveAsync();

    }
}
