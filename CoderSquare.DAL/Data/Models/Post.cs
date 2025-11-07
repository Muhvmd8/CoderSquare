namespace CoderSquare.DAL.Data.Models;
public class Post : BaseEntity<Guid>
{
    #region Fields
    public string Title { get; set; } = default!;
    public string URL { get; set; } = default!;
    public DateTime PostedAt { get; set; } 
    #endregion

    #region Relationships
    public ApplicationUser ApplicationUser { get; set; } = default!;
    public string UserId { get; set; } = default!;
    public ICollection<Like> Likes { get; set; } = [];
    public ICollection<Comment> Comments { get; set; } = [];   
    #endregion
}