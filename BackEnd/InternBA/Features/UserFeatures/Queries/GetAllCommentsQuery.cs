using InternBA.Infrastructure.Data;
using InternBA.Models;
using InternBA.ViewModels;

namespace InternBA.Features.UserFeatures.Queries
{
    public record  GetAllCommentsQuery(PageParagram pagination) : IRequest<PagedList<Comment>>
    {
        public class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, PagedList<Comment>>
        {
            private readonly InternBADBContext context;

            public GetAllCommentsQueryHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<PagedList<Comment>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
            {
                var comments = PagedList<Comment>.ToPageList(context.Comments.ToList().AsQueryable().Where(c=>c.DeleteAt==null), request.pagination.PageNumber, request.pagination.PageSize);
                return comments;

            }
        }

        


    }
}
