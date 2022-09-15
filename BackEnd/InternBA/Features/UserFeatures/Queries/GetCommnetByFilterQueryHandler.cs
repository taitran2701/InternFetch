using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Queries
{
    public class GetCommentByFilterQueryHandler : IRequestHandler<GetCommnetByFilterQuery, IEnumerable<Comment>>
        {
            private readonly InternBADBContext _context;

            public GetCommentByFilterQueryHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Comment>> Handle(GetCommnetByFilterQuery request, CancellationToken cancellationToken)
            {
                var comments = _context.Comments.Where(c => c.PostID == request.ID && c.DeleteAt == null).OrderBy(c=>c.CreatedDate).ToList();
                
                return comments;
            }
        }
    }

