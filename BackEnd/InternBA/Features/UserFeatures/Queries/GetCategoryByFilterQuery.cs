using InternBA.Models;

namespace InternBA.Features.UserFeatures.Queries
{
    public record GetCategoryByFilterQuery(Guid ID) : IRequest<IEnumerable<Category>>
    {
    }
}
