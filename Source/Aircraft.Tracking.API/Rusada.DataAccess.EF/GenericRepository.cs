using Microsoft.EntityFrameworkCore;
using Rusada.Core.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Rusada.DataAccess.EF
{
    
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext context;

        public GenericRepository(DbContext context)
        {
            this.context = context;
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }
        public async Task<TEntity> GetAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            return context.Set<TEntity>().Where(match).ToList();
        }

        public TEntity Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);            
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return entity;

        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }
    }
}
