using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Queries
{
    public record class GetPostByIdQuery(Guid id) : IRequest<Post>
    {
        public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Post>
        {
            private readonly InternBADBContext context;

            public GetPostByIdQueryHandler(InternBADBContext context)
            {
                this.context = context;
            }
            public async Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
            {
                var post = context.Posts.Where(p => p.ID == request.id).FirstOrDefault();
                if (post == null)
                    return null;
                return post;
            }
        }
    }
}
