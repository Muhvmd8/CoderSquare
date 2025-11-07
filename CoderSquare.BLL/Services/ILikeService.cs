namespace CoderSquare.BLL.Services;
public interface ILikeService
{
    Task<LikeToggleResponse> ToggleLikeAsync(LikeToggleRequest request, string userId);
    Task<int> GetLikesCountAsync(Guid postId);
    Task<IEnumerable<LikeDto>> GetPostLikesAsync(Guid postId);
    Task<LikeDto?> GetLikeAsync(int id);
}