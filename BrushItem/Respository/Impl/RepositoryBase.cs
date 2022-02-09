using AutoMapper;
using BrushItem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrushItem.Respository.Impl
{
    public class RepositoryBase<T>: IRepositoryBase<T> where T : class
    {
        private readonly BrushDbContext context;

        public RepositoryBase(BrushDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(context.Set<T>().AsEnumerable());
        }

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
