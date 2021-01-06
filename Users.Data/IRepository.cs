using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Users.Data
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        Task DeleteFromDbAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(Guid id);
        Task<TEntity> GetFirstWhereAsync(Expression<Func<TEntity, bool>> match);
        Task<TEntity> UpdateAsync(TEntity entityToUpdate);
        Task<TEntity> InsertAsync(TEntity entity);
    }
}
