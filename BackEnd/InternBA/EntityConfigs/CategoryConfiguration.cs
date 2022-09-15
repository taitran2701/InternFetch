using InternBA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InternBA.EntityConfigs
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(t=>t.ID);
            builder.Property(t => t.Images).HasMaxLength(500);
            builder.Property(t=>t.Video).HasMaxLength(500);

            builder.HasOne(u => u.Post)
               .WithMany(p => p.Categories)
               .HasForeignKey(u => u.PostID);

        }
    }
}
