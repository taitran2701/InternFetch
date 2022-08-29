using Serilog;

namespace InternBA.Extensions
{
    public static class AddSerilogExtension
    {
        public static IServiceCollection AddMySerilogExtension(this IServiceCollection serviceCollection, WebApplicationBuilder builder)
        {
            
            var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .Enrich.FromLogContext()
                .CreateLogger();
            builder.Logging.ClearProviders();
            builder.Logging.AddSerilog(logger);
            return serviceCollection;
        }
    }
}
