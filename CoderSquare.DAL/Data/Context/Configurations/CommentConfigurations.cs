namespace CoderSquare.DAL.Data.Context.Configurations;
internal class CommentConfigurations : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.Property(c => c.PostedAt)
            .HasDefaultValueSql("GETDATE()");

        // Post has many comments => 1 : M
        builder.HasOne(c => c.Post)
               .WithMany(p => p.Comments)
               .HasForeignKey(c => c.PostId)
               .OnDelete(DeleteBehavior.Cascade);

        // User can create many comments => 1 : M
        builder.HasOne(c => c.ApplicationUser)
               .WithMany(u => u.Comments)
               .HasForeignKey(c => c.UserId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}