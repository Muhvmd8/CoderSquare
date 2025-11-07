namespace CoderSquare.DAL.Data.Context.Configurations;
internal class PostConfigurations : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(p => p.PostedAt)
            .HasDefaultValueSql("GETDATE()");

        // User create posts => 1 : M
        builder.HasOne(p => p.ApplicationUser)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.UserId);
    }
}
