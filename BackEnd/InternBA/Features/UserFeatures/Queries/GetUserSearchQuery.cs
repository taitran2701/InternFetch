namespace InternBA.Features.UserFeatures.Queries
{
    public record GetUserSearchQuery(string search) : IRequest<IEnumerable<User>>
    {
    }
}