using InternBA.EntityConfigs;
using InternBA.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


namespace InternBA.Infrastructure.Data
{
    public class InternBADBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserRoom> UserRoom { get; set; }
        //public int MyProperty { get; set; }
        //public DbSet<UserRefreshTokens> UserRefreshToken { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.ApplyConfiguration(new MessageConfiguration());

            builder.ApplyConfiguration(new RoomConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());

            builder.ApplyConfiguration(new UserRoomConfiguration());

            builder.ApplyConfiguration(new PostConfiguration());

            builder.ApplyConfiguration(new ReactionConfiguration());

            builder.ApplyConfiguration(new CommentConfiguration());

            builder.ApplyConfiguration(new AttachmentConfiguration());

            builder.ApplyConfiguration(new CateConfiguration());

            //builder.ApplyConfiguration(new UserRefreshTokensConfiguration());
        }

        public InternBADBContext(DbContextOptions<InternBADBContext> options)
        : base(options)
        { }
    }
}


