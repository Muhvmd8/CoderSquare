namespace CoderSquare.DAL.Data.Models;
public class Comment : BaseEntity<int>
{
    #region Attributes
    public string Content { get; set; } = default!;
    public DateTime PostedAt { get; set; } 
    #endregion

    #region Relationships
    public Post Post { get; set; } = default!;
    public Guid PostId { get; set; }
    public ApplicationUser ApplicationUser { get; set; } = default!;
    public string UserId { get; set; } = default!; 
    #endregion
}