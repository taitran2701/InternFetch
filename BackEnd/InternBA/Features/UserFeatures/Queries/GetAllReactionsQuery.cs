using InternBA.Infrastructure.Data;
using InternBA.Models;
using InternBA.ViewModels;

namespace InternBA.Features.UserFeatures.Queries
{
    public record GetAllReactionsQuery(PageParagram pagination) : IRequest<PagedList<Reaction>>
    {
        public class GetAllReactionsQueryHandler : IRequestHandler<GetAllReactionsQuery,PagedList<Reaction>>
        {
            private readonly InternBADBContext context;

            public GetAllReactionsQueryHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<PagedList<Reaction>> Handle(GetAllReactionsQuery request, CancellationToken cancellationToken)
            {
                var reactions =  PagedList<Reaction>.ToPageList(context.Reactions.ToList().AsQueryable(),request.pagination.PageNumber, request.pagination.PageSize);
                return reactions;
            }
        }
    }
}
