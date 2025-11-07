namespace CoderSquare.BLL.DataTransferObjects.PostDTO;
public class PostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string URL { get; set; } = default!;
    public DateTime PostedAt { get; set; }
    public long LikesCount { get; set; }
    public long CommentsCount { get; set; }
    public string AuthorUserName { get; set; } = default!;
    public string AuthorName { get; set; } = default!;
    public string? AuthorProfileImageUrl { get; set; }
}