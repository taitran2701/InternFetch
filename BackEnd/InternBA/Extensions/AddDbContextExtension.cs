using Microsoft.EntityFrameworkCore;

namespace InternBA.Extensions
{
    public static class AddDbContextExtension
    {
        public static IServiceCollection AddMyDbContext(this IServiceCollection servicserviceCollection, WebApplicationBuilder builder)
        {
            servicserviceCollection.AddDbContext<InternBADBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("mydata"));
            });
            return servicserviceCollection;
        }
    }
}
