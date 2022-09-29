using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Queries
{
    public class GetReactionByFilterQueryHandler : IRequestHandler<GetReactionByFilterQuery, IEnumerable<Reaction>>
    {
        private readonly InternBADBContext _context;

        public GetReactionByFilterQueryHandler(InternBADBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Reaction>> Handle(GetReactionByFilterQuery request, CancellationToken cancellationToken)
        {
            var reactions = _context.Reactions.Where(r => r.PostID == request.ID && r.DeleteAt == null).ToList();

            return reactions;
        }
    }
}
