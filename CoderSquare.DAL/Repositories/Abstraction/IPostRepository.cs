namespace CoderSquare.DAL.Repositories.Abstraction;
public interface IPostRepository : IGenericRepository<Post, Guid>
{
    Task<IEnumerable<Post>> GetAllAsync(string userId);
    Task<Post?> GetByIdWithIncludesAsync(Guid postId);
}
