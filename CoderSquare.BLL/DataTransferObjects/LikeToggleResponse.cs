namespace CoderSquare.BLL.DataTransferObjects;
public class LikeToggleResponse
{
    public Guid PostId { get; set; }
    public bool IsLiked { get; set; }
    public int TotalLikes { get; set; }
}
