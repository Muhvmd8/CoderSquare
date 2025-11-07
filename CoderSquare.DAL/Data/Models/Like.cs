namespace CoderSquare.DAL.Data.Models;
public class Like : BaseEntity<int>
{
    public DateTime LikedAt { get; set; }
    #region Relationships
    public ApplicationUser ApplicationUser { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public Post Post { get; set; } = default!;
    public Guid PostId { get; set; } = default!; 
    #endregion
}