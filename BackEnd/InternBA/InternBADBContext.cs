using InternBA.EntityConfigs;
using InternBA.Models;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Infrastructure.Data
{
    public class InternBADBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }
        //public int MyProperty { get; set; }
        //public DbSet<UserRefreshTokens> UserRefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.ApplyConfiguration(new MessageConfiguration());

            builder.ApplyConfiguration(new RoomConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new UserRoomConfiguration());

            //builder.ApplyConfiguration(new UserRefreshTokensConfiguration());
        }

        public InternBADBContext(DbContextOptions<InternBADBContext> options)
        : base(options)
        {
        }

    }
}
