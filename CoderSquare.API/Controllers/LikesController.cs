namespace CoderSquare.API.Controllers;
[Authorize]
public class LikesController(ILikeService likeService)
    : ApiController
{
    private readonly ILikeService _likeService = likeService;
    [HttpPost("Toggle")]
    public async Task<ActionResult<LikeToggleResponse>> ToggleLike([FromBody] LikeToggleRequest request)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var response = await _likeService.ToggleLikeAsync(request, userId!);
        return Ok(response);
    }
    [AllowAnonymous]
    [HttpGet("Count/{postId}")]
    public async Task<ActionResult<int>> GetLikesCount(Guid postId)
    {
        var count = await _likeService.GetLikesCountAsync(postId);
        return Ok(count);
    }
    [AllowAnonymous]
    [HttpGet("Users/{postId}")]
    public async Task<ActionResult<IEnumerable<LikeDto>>> GetLikes(Guid postId)
    {
        var likes = await _likeService.GetPostLikesAsync(postId);
        return Ok(likes);
    }
    [HttpGet("Like/{id}")]
    public async Task<ActionResult<LikeDto>> GetLike(int id)
    {
        var like = await _likeService.GetLikeAsync(id);
        return Ok(like);
    }
}