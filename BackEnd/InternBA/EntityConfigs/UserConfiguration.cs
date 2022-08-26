using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternBA.EntityConfigs
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.ID);
            builder.HasMany(u => u.Room);

            builder.Property(u => u.Username)
                .HasColumnName("Username")
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(u => u.Password).IsRequired();

            builder.HasMany(p=>p.Posts)
                .WithOne(u=>u.User)
                .HasForeignKey(u=>u.UserID);

        }
    }
}
