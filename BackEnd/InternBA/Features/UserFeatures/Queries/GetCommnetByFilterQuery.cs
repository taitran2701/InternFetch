using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Queries
{
    public record class GetCommnetByFilterQuery(Guid postid) : IRequest<Comment>
    {
        public class GetCommentByFilterQueryHandler : IRequestHandler<GetCommnetByFilterQuery, Comment>
        {
            private readonly InternBADBContext context;

            public GetCommentByFilterQueryHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Comment> Handle(GetCommnetByFilterQuery request, CancellationToken cancellationToken)
            {
                var comment = context.Comments.Where(c => c.PostID == request.postid).OrderBy(c=>c.CreatedDate).FirstOrDefault();
                if (comment == null) return null;
                return comment;
            }
        }
    }
}
