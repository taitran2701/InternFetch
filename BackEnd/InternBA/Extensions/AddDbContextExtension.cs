using Microsoft.EntityFrameworkCore;

namespace InternBA.Extensions
{
    public static class AddDbContextExtension
    {
        public static IServiceCollection AddMyDbContext(this IServiceCollection servicserviceCollection, IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(nameof(servicserviceCollection));   
            ArgumentNullException.ThrowIfNull(nameof(configuration));
            
            servicserviceCollection.AddDbContext<InternBADBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("mydata"));
            });
            return servicserviceCollection;
        }
    }
}
