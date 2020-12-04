using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.DataAccess.EntityFrameworkCore.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : class, new()
    {
        Task<List<TEntity>> GetAllASync();
        Task<List<TEntity>> GetAllASync(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAllASync<TKey>(Expression<Func<TEntity, TKey>> keySelector);
        Task<List<TEntity>> GetAllASync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector);
        TEntity Find(Expression<Func<TEntity, bool>> where);

        Task<TEntity> FindByIdAsync(int id);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);

    }
}
