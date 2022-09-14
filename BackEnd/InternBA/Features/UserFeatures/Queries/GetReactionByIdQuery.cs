using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Queries
{
    public record class GetReactionByIdQuery(Guid id) : IRequest<Reaction>
    {
        public class GetReactionByIdQueryHandler : IRequestHandler<GetReactionByIdQuery,Reaction>
        {
            private readonly InternBADBContext context;
            public GetReactionByIdQueryHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Reaction> Handle(GetReactionByIdQuery request, CancellationToken cancellationToken)
            {
                var reaction = context.Reactions.Where(r=>r.ID == request.id).FirstOrDefault();
                if (reaction == null) return null;
                return reaction;
            }
        }
    }
}
