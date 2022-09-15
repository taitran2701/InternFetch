using InternBA.Models;

namespace InternBA.Features.UserFeatures.Queries
{
    public record GetCommnetByFilterQuery(Guid ID) : IRequest<IEnumerable<Comment>>
    {
    }
}