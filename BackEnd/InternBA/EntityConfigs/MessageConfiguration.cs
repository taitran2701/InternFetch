using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternBA.EntityConfigs
{
    public class MessageConfiguration : IEntityTypeConfiguration<Message>
    {
        public void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.HasKey(message => message.ID);
            builder.Property(p => p.ID).HasColumnName("ID");
            builder.HasOne(p => p.Room);
            builder.Property(m => m.UserId).HasColumnName("UserId");
            builder.Property(m => m.Content).HasColumnName("Message");
            builder.Property(m => m.Content).HasMaxLength(150);
            
        }
    }
}
