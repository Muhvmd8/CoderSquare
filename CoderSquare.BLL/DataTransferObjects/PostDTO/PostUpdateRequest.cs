namespace CoderSquare.BLL.Services;
public class PostUpdateRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string URL { get; set; } = default!;
}