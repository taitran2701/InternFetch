using InternBA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternBA.EntityConfigs
{
    public class UserRefreshTokensConfiguration : IEntityTypeConfiguration<UserRefreshTokens>
    {
        public void Configure(EntityTypeBuilder<UserRefreshTokens> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.RefreshToken).IsRequired();
        }
    }
}
