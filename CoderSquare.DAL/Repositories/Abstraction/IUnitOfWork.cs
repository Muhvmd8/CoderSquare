namespace CoderSquare.DAL.Repositories.Abstraction;
public interface IUnitOfWork
{
    TRepository GetRepository<TRepository, TEntity, TKey>()
        where TRepository : class, IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>;
    Task<int> SaveChangesAsync();
}