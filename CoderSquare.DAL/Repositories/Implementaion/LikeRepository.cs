using CoderSquare.DAL.Repositories.Abstraction;

namespace CoderSquare.DAL.Repositories.Implementaion;
public class LikeRepository(CoderSquareDbContext context)
    : GenericRepository<Like, int>(context),
    ILikeRepository
{
    private readonly CoderSquareDbContext _context = context;
    public async Task<int> CountAsync(Guid postId)
        => await _context.Likes.CountAsync(l => l.PostId == postId);
    public async Task<IEnumerable<Like>> GetAllAsync(Guid postId)
        => await _context.Likes.AsNoTracking()
                               .Where(l => l.PostId == postId)
                               .ToListAsync();
    public async Task<Like?> GetByUserAndPostAsync(string userId, Guid postId)
        => await _context.Likes.FirstOrDefaultAsync(l => l.PostId == postId && l.UserId == userId);
}