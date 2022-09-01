namespace InternBA.Features.UserFeatures.Queries
{
    public record GetUserFriendQuery(string username) : IRequest<IEnumerable<User>>
    {
    }
}