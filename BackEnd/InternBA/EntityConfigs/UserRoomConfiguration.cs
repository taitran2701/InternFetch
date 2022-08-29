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

            builder.HasOne<User>(ur => ur.User)
                .WithMany(u => u.UserRooms)
                .HasForeignKey(u => u.UserId);

            builder.HasOne<Room>(ur => ur.Room)
                .WithMany(r => r.UserRooms)
                .HasForeignKey(r => r.RoomId);

            builder.Property(ur => ur.ID).HasColumnOrder(0);
        }
    }
}
