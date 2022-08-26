using InternBA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InternBA.EntityConfigs
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasKey(a =>a.ID);


            builder.HasOne(c=>c.Category)
                .WithMany(a=>a.Attachments)
                .HasForeignKey(c=>c.CategoryId);

            builder.HasOne(p=>p.Post)
                .WithMany(a=>a.Attachments)
                .HasForeignKey(p=>p.PostID);

        }
    }
}
