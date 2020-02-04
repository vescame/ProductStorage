using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProductStorage.Core.Repositories;

namespace ProductStorage.Data.Repositories
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly StorageContextMySql _context;

        public Repository(StorageContextMySql context)
        {
            _context = context;
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(long id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await Task.Factory.StartNew(() =>
            {
                _context.Set<TEntity>().Add(entity);
                return entity;
            });

            return;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Factory.StartNew(() =>
            {
                _context.Set<TEntity>().AddRange(entities);
                return entities;
            });

            return;
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }        
    }
}
