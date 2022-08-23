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

            builder.HasOne(c => c.Post);

            builder.Property(c => c.Content)
                .HasColumnName("Content")
                .IsRequired()
                .HasMaxLength(500);

            builder.HasMany(c => c.Reactions);
       

        }
    }
}
