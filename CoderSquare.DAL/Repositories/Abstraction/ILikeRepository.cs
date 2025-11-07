namespace CoderSquare.DAL.Repositories.Abstraction;
public interface ILikeRepository : IGenericRepository<Like, int>
{
    Task<IEnumerable<Like>> GetAllAsync(Guid postId);
    Task<Like?> GetByUserAndPostAsync(string userId, Guid postId);
    Task<int> CountAsync(Guid postId);
}