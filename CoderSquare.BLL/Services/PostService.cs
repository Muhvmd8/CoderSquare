namespace CoderSquare.BLL.Services;
public class PostService(IUnitOfWork unitOfWork) : IPostService
{
    private readonly IPostRepository repository = unitOfWork.GetRepository<IPostRepository, Post, Guid>();
    public async Task<IEnumerable<PostDto>> GetAllAsync(string userId)
    {
        var posts = await repository.GetAllAsync(userId);
        var postsDto = posts.ToPostResponse();
        return postsDto;
    }
    public async Task<PostDto> GetByIdAsync(Guid postId)
    {
        var post = await repository.GetByIdWithIncludesAsync(postId)??
            throw new PostNotFoundException(postId.ToString());

        return post.ToPostDto();
    }
    public async Task<PostResponse> AddAsync(PostCreateRequest request)
    {
        var newPost = request.ToEntity();

        await repository.AddAsync(newPost);
        await unitOfWork.SaveChangesAsync();

        var response = newPost.ToPostResponse();
        return response;

    }
    public async Task<PostResponse> Update(PostUpdateRequest request)
    {
        var existingPost = await repository.GetByIdWithIncludesAsync(request.Id)??
            throw new PostNotFoundException(request.Id.ToString());

        existingPost.Title = request.Title;
        existingPost.URL = request.URL;

        repository.Update(existingPost);
        await unitOfWork.SaveChangesAsync();

        var response = existingPost.ToPostResponse();
        return response;
    }
    public async Task<DeletePostResponse> Delete(Guid postId)
    {
        var post = await repository.GetByIdAsync(postId)?? 
            throw new PostNotFoundException(postId.ToString());

        repository.Delete(post);
        await unitOfWork.SaveChangesAsync();

        return new DeletePostResponse
        {
            Id = postId,
            DeletedAt = DateTime.Now,
            Message = "Post is deleted successfully"
        };
    }
    public async Task<IEnumerable<PostDto>> GetAllAsync()
    {
        var posts = await repository.GetAllAsync();
        var postsDto = posts.Select(p => new PostDto
        {
            Id = p.Id,
            PostedAt = p.PostedAt,
            Title = p.Title,
            URL = p.URL
        });
        return postsDto;
    }
}