using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternBA.EntityConfigs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.HasMany(u => u.Room);
            builder.HasMany(u=> u.Posts);
            builder.Property(u => u.Username)
                .HasColumnName("Username")
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(u => u.Password).IsRequired();

        }
    }
}
