using InternBA.EntityConfigs;
using InternBA.Models;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace InternBA
{
    public class InternBADBContext : DbContext
    {
        public InternBADBContext(DbContextOptions<InternBADBContext> options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PostConfiguration());

            builder.ApplyConfiguration(new ReactionConfiguration());

            builder.ApplyConfiguration(new CommentConfiguration());

            builder.ApplyConfiguration(new AttachmentConfiguration());

            builder.ApplyConfiguration(new CateConfiguration());

        }

    }
}
