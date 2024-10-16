

using Core.Entities;

namespace Core.Repository;

public interface IRepository<TEntity,TId>
    where TEntity : Entity<TId>, new()
{
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    TEntity Delete(TEntity entity);
    TEntity? GetById(TId id);
    List<TEntity> GetAll();
}
