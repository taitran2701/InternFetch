using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Queries
{
    public record class GetCategoryByIdQuery(Guid id) : IRequest<Category>
    {
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
        {
            private readonly InternBADBContext context;

            public GetCategoryByIdQueryHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
            {
                var category = context.Categories.Where(c =>c.ID == request.id).FirstOrDefault();
                if (category == null) return null;
                return category;
            }
        }
    }
}
