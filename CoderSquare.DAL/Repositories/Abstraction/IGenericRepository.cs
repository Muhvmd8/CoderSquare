namespace CoderSquare.DAL.Repositories.Abstraction;
public interface IGenericRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
{
    Task AddAsync(TEntity entity);
    void Delete(TEntity entity);
    void Update(TEntity entity);
    Task<TEntity?> GetByIdAsync(TKey id);
    Task<IEnumerable<TEntity>> GetAllAsync();
}