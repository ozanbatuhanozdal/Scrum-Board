using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;

namespace TestApplication.DataAccess.EntityFrameworkCore.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class, new()
    {
        public async Task AddAsync(TEntity entity)
        {
            using var context = new DatabaseContext();
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }
        
        public virtual async Task<List<TEntity>> GetAllASync()
        {
            using var context = new DatabaseContext();
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllASync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new DatabaseContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllASync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new DatabaseContext();
            return await context.Set<TEntity>().Where(filter).ToListAsync();
        }

        public async Task<List<TEntity>> GetAllASync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            using var context = new DatabaseContext();
            return await context.Set<TEntity>().OrderByDescending(keySelector).ToListAsync();
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            using var context = new DatabaseContext();
            return context.Set<TEntity>().FirstOrDefault(where);
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            using var context = new DatabaseContext();
            return await context.FindAsync<TEntity>(id);
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            using var context = new DatabaseContext();
            return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            using var context = new DatabaseContext();

            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            using var context = new DatabaseContext();
            context.Update(entity);
            await context.SaveChangesAsync();
        }

    }
}
