namespace CoderSquare.BLL.Services;
public class LikeService(IUnitOfWork unitOfWork) : ILikeService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<LikeDto?> GetLikeAsync(int id)
    { 
        var like = await _unitOfWork.GetRepository<ILikeRepository, Like, int>()
                                    .GetByIdAsync(id)?? throw new LikeNotFoundException(id);
        return new LikeDto
        {
            LikedAt = like.LikedAt,
            PostId = like.PostId,
            UserId = like.UserId
        };
    }
    public async Task<int> GetLikesCountAsync(Guid postId)
    {
        var likeRepository = _unitOfWork.GetRepository<ILikeRepository, Like, int>();
        return await likeRepository.CountAsync(postId);
    }
    public async Task<IEnumerable<LikeDto>> GetPostLikesAsync(Guid postId)
    {
        var likeRepository = _unitOfWork.GetRepository<ILikeRepository, Like, int>();
        var likes = await likeRepository.GetAllAsync(postId);

        return likes.Select(like => new LikeDto
        {
            PostId = postId,
            UserId = like.UserId,
            LikedAt = like.LikedAt
        });
    }
    public async Task<LikeToggleResponse> ToggleLikeAsync(LikeToggleRequest request, string userId)
    {
        // Check if Post exists
        var postRepository = _unitOfWork.GetRepository<PostRepository, Post, Guid>();
        var post = await postRepository.GetByIdAsync(request.PostId)
            ?? throw new PostNotFoundException(request.PostId.ToString());

        var likeRepository = _unitOfWork.GetRepository<ILikeRepository, Like, int>();

        var existingLike = await likeRepository.GetByUserAndPostAsync(userId, request.PostId);

        bool isLiked;

        if (existingLike is null)
        {
            var newLike = new Like
            {
                LikedAt = DateTime.Now,
                PostId = request.PostId,
                UserId = userId
            };

            await likeRepository.AddAsync(newLike);
            isLiked = true;
        }
        else
        {
            likeRepository.Delete(existingLike);
            isLiked = false;
        }

        await _unitOfWork.SaveChangesAsync();

        // Count after updating
        var totalLikes = await likeRepository.CountAsync(request.PostId);

        return new LikeToggleResponse
        {
            PostId = request.PostId,
            IsLiked = isLiked,
            TotalLikes = totalLikes
        };
    }
}