using InternBA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InternBA.EntityConfigs
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(p => p.ID);

            builder.Property(p => p.Content)
                .IsRequired()
                .HasMaxLength(500);

            //builder.HasMany(p => p.Reactions);

            builder.HasOne(u => u.User)
                .WithMany(p => p.Posts)
                .HasForeignKey( u=> u.UserID);

            
        }
    }
}
