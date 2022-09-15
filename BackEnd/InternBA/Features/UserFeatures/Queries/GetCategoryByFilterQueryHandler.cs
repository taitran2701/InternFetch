using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Queries
{
    public class GetCategoryByFilterQueryHandler : IRequestHandler<GetCategoryByFilterQuery, IEnumerable<Category>>
    {
        private readonly InternBADBContext _context;

        public GetCategoryByFilterQueryHandler(InternBADBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> Handle(GetCategoryByFilterQuery request, CancellationToken cancellationToken)
        {
            var comments = _context.Categories.Where(c => c.PostID == request.ID && c.DeleteAt == null).OrderBy(c => c.CreatedDate).ToList();

            return comments;
        }

       
    }
}

