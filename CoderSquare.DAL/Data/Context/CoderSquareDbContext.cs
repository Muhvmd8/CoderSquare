namespace CoderSquare.DAL.Data.Context;
public class CoderSquareDbContext(DbContextOptions options) 
    : IdentityDbContext(options)
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
    }
}