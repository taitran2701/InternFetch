using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Queries
{
    public record class GetCommentByIdQuery(Guid id) : IRequest<Comment>
    {
        public class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, Comment>
        {
            private readonly InternBADBContext context;
            public GetCommentByIdQueryHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Comment> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
            {
                var comment = context.Comments.Where(c=>c.ID == request.id).FirstOrDefault();
                if( comment == null) return null;
                return comment;
            }
        }
    }
}
