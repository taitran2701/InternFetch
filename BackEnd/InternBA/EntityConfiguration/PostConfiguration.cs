using InternBA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace InternBA.EntityConfiguration

{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            throw new NotImplementedException();
        }

       
    }
}
