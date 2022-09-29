using InternBA.Models;

namespace InternBA.Features.UserFeatures.Queries
{
    public record GetReactionByFilterQuery(Guid ID) : IRequest<IEnumerable<Reaction>>
    {
    }
}
