namespace CoderSquare.BLL.Factories;
public static class PostFactory
{
    public static IEnumerable<PostDto> ToPostResponse(this IEnumerable<Post> posts)
        => posts.Select(p => new PostDto
        {
            Id = p.Id,
            PostedAt = p.PostedAt,
            Title = p.Title,
            URL = p.URL,
            AuthorName = $"{p.ApplicationUser.FirstName} {p.ApplicationUser.LastName}",
            AuthorUserName = p.ApplicationUser.UserName!,
            CommentsCount = p.Comments.Count,
            LikesCount = p.Likes.Count,
        });
    public static PostResponse ToPostResponse(this Post post)
        => new PostResponse
        {
            PostedAt = post.PostedAt,
            Id = post.Id,
            Title = post.Title,
            URL = post.URL
        };
    public static PostDto ToPostDto(this Post post)
        => new PostDto
        {
            Id = post.Id,
            URL = post.URL,
            Title = post.Title,
            PostedAt = post.PostedAt,
            AuthorName = $"{post.ApplicationUser.FirstName} {post.ApplicationUser.LastName}",
            AuthorUserName = post.ApplicationUser.UserName!,
            CommentsCount = post.Comments.Count,
            LikesCount = post.Likes.Count,
        };
    public static Post ToEntity(this PostCreateRequest request)
        => new Post
        {
            Id = Guid.NewGuid(),
            UserId = request.UserId,
            Title = request.Title,
            URL = request.URL
        };
    public static Post ToEntity(this PostUpdateRequest request)
        => new Post
    {
        Id = request.Id,
        Title = request.Title,
        URL = request.URL
    };
}
