using CoderSquare.DAL.Repositories.Abstraction;

public class UnitOfWork : IUnitOfWork
{
    private readonly IServiceProvider _serviceProvider;
    private readonly CoderSquareDbContext _dbContext;
    private readonly Dictionary<Type, object> _repositories = new();

    public UnitOfWork(CoderSquareDbContext dbContext, IServiceProvider serviceProvider)
    {
        _dbContext = dbContext;
        _serviceProvider = serviceProvider;
    }

    public TRepository GetRepository<TRepository, TEntity, TKey>()
        where TRepository : class, IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
    {
        var type = typeof(TRepository);

        if (_repositories.TryGetValue(type, out var repo))
            return (TRepository)repo;

        var repository = _serviceProvider.GetRequiredService<TRepository>();
        _repositories[type] = repository;

        return repository;
    }

    public async Task<int> SaveChangesAsync() => await _dbContext.SaveChangesAsync();
}
