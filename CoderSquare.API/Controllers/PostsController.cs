namespace CoderSquare.API.Controllers;
public class PostsController(IPostService postService) : ApiController
{
    // Add
    [HttpPost]
    public async Task<ActionResult<PostResponse>> AddAsync(PostCreateRequest request)
    {
        var newPost = await postService.AddAsync(request);
        return Ok(newPost);
    }
    // Update
    [HttpPut("Edit")]
    public async Task<ActionResult<PostResponse>> UpdateAsync(PostUpdateRequest request)
    {
        var updatedPost = await postService.Update(request);
        return Ok(updatedPost);
    }
    // Delete/id
    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletePostResponse>> DeleteAsync(Guid id)
    {
        var deletedPost = await postService.Delete(id);
        return Ok(deletedPost);
    }
    // Get By Post Id
    [HttpGet("{id}")]
    public async Task<ActionResult<PostDto>> GetPostById(Guid id)
    {
        var post = await postService.GetByIdAsync(id);
        return Ok(post);
    }
    // Get All 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPosts()
    {
        var posts = await postService.GetAllAsync();
        return Ok(posts);
    }
    // Get All By User Id
    [HttpGet("UserPosts/{userId}")]
    public async Task<ActionResult<IEnumerable<PostDto>>> GetAllPostsByUserId(string userId)
    {
        var posts = await postService.GetAllAsync(userId);
        return Ok(posts);
    }
}
