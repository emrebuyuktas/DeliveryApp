using DeliveryApp.Core.Entities.Abstaract;
using DeliveryApp.Core.Repositories.Abstract;
using DeliveryApp.Data.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeliveryApp.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : class, IEntity, new()
    {
        protected readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => { _context.Set<T>().Remove(entity); });
        }

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = query.Where(predicate);

            if (includeProperties.Any())
            {
                foreach (var includeProperty in includeProperties)
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.SingleOrDefaultAsync();
        }

        public async Task<IList<T>> SearchAsync(IList<Expression<Func<T, bool>>> predicates, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            if (predicates.Any())
            {
                foreach (var q in predicates)
                {
                    query = query.Where(q);
                }
            }
            if (includeProperties.Any())
            {
                foreach (var p in includeProperties)
                {
                    query = query.Include(p);
;                }
            }
            return await query.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => { _context.Set<T>().Update(entity); });
        }
    }
}
