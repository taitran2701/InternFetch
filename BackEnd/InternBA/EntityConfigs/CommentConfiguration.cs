using InternBA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InternBA.EntityConfigs
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(c =>c.ID);

            builder.Property(c => c.Content)
                .HasColumnName("Content")
                .IsRequired()
                .HasMaxLength(500);

            

            builder.HasOne(c=>c.Post)
                .WithMany(c=>c.Comments)
                .HasForeignKey(c=>c.PostID);

            builder.HasOne(u=>u.User)
                .WithMany(c=>c.Comments)
                .HasForeignKey(u=>u.UserID);
       

        }
    }
}
