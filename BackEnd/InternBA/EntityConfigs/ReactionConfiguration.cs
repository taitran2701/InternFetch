using InternBA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InternBA.EntityConfigs
{
    public class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
    {
        public void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.HasKey(r => r.ID);

            builder.Property(r => r.Expression)
                .HasMaxLength(500)
                .HasColumnName("Type");


            builder.HasOne(r => r.Comment);

            builder.HasOne(r => r.Post)
                .WithMany(x=>x.Reactions)
                .HasForeignKey(x=>x.PostID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
