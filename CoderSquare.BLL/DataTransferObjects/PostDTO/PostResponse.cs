namespace CoderSquare.BLL.DataTransferObjects.PostDTO;
public class PostResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string URL { get; set; } = default!;
    public DateTime PostedAt { get; set; }
}
