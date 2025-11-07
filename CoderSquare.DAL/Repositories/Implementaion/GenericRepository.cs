namespace CoderSquare.DAL.Repositories.Implementaion;
public class GenericRepository<TEntity, TKey>(CoderSquareDbContext coderSquareDb)
    : IGenericRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
{
    public async Task<IEnumerable<TEntity>> GetAllAsync()
        => await coderSquareDb.Set<TEntity>().AsNoTracking().ToListAsync();
    public async Task<TEntity?> GetByIdAsync(TKey id)
        => await coderSquareDb.Set<TEntity>().FindAsync(id);
    public async Task AddAsync(TEntity entity)
        => await coderSquareDb.Set<TEntity>().AddAsync(entity);
    public void Delete(TEntity entity)
        => coderSquareDb.Set<TEntity>().Remove(entity);
    public void Update(TEntity entity)
        => coderSquareDb.Set<TEntity>().Update(entity);
}