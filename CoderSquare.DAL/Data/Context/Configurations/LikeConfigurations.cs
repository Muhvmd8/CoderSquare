namespace CoderSquare.DAL.Data.Context.Configurations;
internal class LikeConfigurations : IEntityTypeConfiguration<Like>
{
    public void Configure(EntityTypeBuilder<Like> builder)
    {
        builder.HasKey(l => l.UserId);

        builder.HasOne(l => l.ApplicationUser)
               .WithMany(u => u.Likes)
               .HasForeignKey(l => l.UserId)
               .OnDelete(DeleteBehavior.NoAction); 


        builder.HasOne(l => l.Post)
               .WithMany(p => p.Likes)
               .HasForeignKey(l => l.PostId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
