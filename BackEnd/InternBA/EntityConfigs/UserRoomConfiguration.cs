using InternBA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternBA.EntityConfigs
{
    public class UserRoomConfiguration : IEntityTypeConfiguration<UserRoom>
    {
        public void Configure(EntityTypeBuilder<UserRoom> builder)
        {
            builder.HasKey(x => new { x.UserId, x.RoomId });
        }
    }
}
