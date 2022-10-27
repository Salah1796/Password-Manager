using PasswordManager.Application.Common.Models;
using PasswordManager.Domain.Common.Contracts;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PasswordManager.Application.Contracts.Persistence.IRepositories.Base
{
    public interface IBaseRepositoryAsync<TEntity, TPrimeryKey> : IDisposable
         where TEntity : class, IEntityIdentity<TPrimeryKey>
    {
        Task<TEntity> GetByIdAsync(TPrimeryKey id);
        public IQueryable<TEntity> Get();
        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        TEntity Update(TEntity entity);
        void Delete(TEntity entity);
        Task Delete(TPrimeryKey id);

        Task<long> GetCountAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> SetSortOrder(IQueryable<TEntity> source, string sortOrder);
        public IQueryable<TEntity> SetPagination(IQueryable<TEntity> source, Pagination pagination);
        Task<Pagination> SetPaginationCount(IQueryable<TEntity> source, Pagination pagination);
    }
}
