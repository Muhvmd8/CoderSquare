using CoderSquare.DAL.Repositories.Abstraction;

namespace CoderSquare.DAL.Repositories.Implementaion;
public class PostRepository(CoderSquareDbContext context)
    : GenericRepository<Post, Guid>(context), IPostRepository
{
    private readonly CoderSquareDbContext _context = context;
    public async Task<IEnumerable<Post>> GetAllAsync(string userId)
        => await _context.Posts.AsNoTracking()
            .Where(p => p.UserId == userId)
            .Include(p => p.Likes)
            .Include(p => p.ApplicationUser)
            .Include(p => p.Comments)
            .ToListAsync();
    public async Task<Post?> GetByIdWithIncludesAsync(Guid postId)
        => await _context.Posts.AsNoTracking()
            .Include(p => p.ApplicationUser)
            .Include(p => p.Likes)
            .Include(p => p.Comments)
            .FirstOrDefaultAsync(p => p.Id == postId);
}
