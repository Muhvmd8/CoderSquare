namespace CoderSquare.DAL.Data.Models;
public class ApplicationUser : IdentityUser
{
    #region Attributes
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    #endregion

    #region Relationships 
    public ICollection<Like> Likes { get; set; } = default!;
    public ICollection<Comment> Comments { get; set; } = [];
    public ICollection<Post> Posts { get; set; } = []; 
    #endregion
}