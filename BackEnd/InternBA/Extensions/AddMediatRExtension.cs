using MediatR;

namespace InternBA.Extensions
{
    public static class AddMediatRExtension
    {
        public static IServiceCollection AddMyMediatR(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR();
            return serviceCollection;
        }
    }
}
