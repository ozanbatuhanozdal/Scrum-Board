using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TestApplication.BusinessLayer.Interfaces
{
    public interface IManagerBase<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllASync();
        Task<List<TEntity>> GetAllASync(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAllASync<TKey>(Expression<Func<TEntity, TKey>> keySelector);
        Task<List<TEntity>> GetAllASync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        TEntity Find(Expression<Func<TEntity, bool>> where);
        Task<TEntity> FindById(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
