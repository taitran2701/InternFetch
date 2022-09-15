using InternBA.Infrastructure.Data;
using InternBA.Models;
using InternBA.ViewModels;

namespace InternBA.Features.UserFeatures.Queries
{
    public record class GetAllCategoriesQuery(PageParagram pagination) : IRequest<PagedList<Category>>
    {
        public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery,PagedList<Category>>
        {
            private readonly InternBADBContext context;

            public GetAllCategoriesQueryHandler(InternBADBContext context)
            {
                this.context = context;
            }

          

            public async Task<PagedList<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var categories = PagedList<Category>.ToPageList(context.Categories.ToList().AsQueryable().Where(c=>c.DeleteAt==null),request.pagination.PageNumber, request.pagination.PageSize);

                return categories;
            }
        }
    }
}
