namespace CoderSquare.BLL.DataTransferObjects;
public class LikeDto
{
    public string UserId { get; set; } = string.Empty;
    public Guid PostId { get; set; }
    public DateTime LikedAt { get; set; }
}
