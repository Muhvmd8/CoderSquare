namespace CoderSquare.BLL.Services;
public interface IPostService
{
    Task<IEnumerable<PostDto>> GetAllAsync();
    Task<IEnumerable<PostDto>> GetAllAsync(string userId);
    Task<PostDto> GetByIdAsync(Guid postId);
    Task<PostResponse> AddAsync(PostCreateRequest request);
    Task<PostResponse> Update(PostUpdateRequest request);
    Task<DeletePostResponse> Delete(Guid postId);
}
