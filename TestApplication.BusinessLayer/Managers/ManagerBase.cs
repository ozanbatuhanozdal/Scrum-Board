using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestApplication.BusinessLayer.Interfaces;
using TestApplication.DataAccess.EntityFrameworkCore.Interfaces;

namespace TestApplication.BusinessLayer.Managers
{
    public class ManagerBase<TEntity> : IManagerBase<TEntity> where TEntity : class, new()
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ManagerBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task<TEntity> FindById(int id)
        {
            return await _repository.FindByIdAsync(id);
        }

        public async Task<List<TEntity>> GetAllASync()
        {
            return await _repository.GetAllASync();
        }

        public async Task<List<TEntity>> GetAllASync(Expression<Func<TEntity, bool>> filter)
        {
            return await _repository.GetAllASync(filter);
        }

        public async Task<List<TEntity>> GetAllASync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        {
            return await _repository.GetAllASync(keySelector);
        }

        public Task<List<TEntity>> GetAllASync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> keySelector)
        {
            return _repository.GetAllASync(filter, keySelector);
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.GetAsync(filter);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> where)
        {
            return _repository.Find(where);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await _repository.RemoveAsync(entity);
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}
