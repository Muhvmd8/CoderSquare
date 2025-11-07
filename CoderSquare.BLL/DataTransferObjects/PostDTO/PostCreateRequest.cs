namespace CoderSquare.BLL.DataTransferObjects.PostDTO;
public class PostCreateRequest
{
    public string Title { get; set; } = default!;
    public string URL { get; set; } = default!;
    public string UserId { get; set; } = default!;
}