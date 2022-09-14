using InternBA.Infrastructure.Data;
using InternBA.Models;
using InternBA.ViewModels;

namespace InternBA.Features.UserFeatures.Queries
{
    public record GetAllPostsQuery(PageParagram pagination):IRequest<PagedList<Post>>
    {
        public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, PagedList<Post>>
        {
            private readonly InternBADBContext context;

            public GetAllPostsQueryHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<PagedList<Post>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
            {
                var posts = PagedList<Post>.ToPageList(context.Posts.ToList().AsQueryable().Where(p=>p.DeleteAt == null), request.pagination.PageNumber, request.pagination.PageSize);
                return posts;
            }
        }
    }
}
