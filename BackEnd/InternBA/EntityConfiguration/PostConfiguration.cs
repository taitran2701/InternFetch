using InternBA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InternBA.EntityConfiguration

{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(Post => Post.ID);

            builder.Property(p => p.ID);
            builder.Property(p => p.UserID);

            builder.HasMany(p=>p.Attachments);
            builder.HasMany(p=>p.Reactions);
            builder.HasMany(p=>p.Comments);

            builder.Property(p => p.Content).HasMaxLength(500);
            
        }
    }
}
