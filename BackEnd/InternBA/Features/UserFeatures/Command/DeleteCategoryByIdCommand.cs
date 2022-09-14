using InternBA.Infrastructure.Data;
using System.Data.Entity;

namespace InternBA.Features.UserFeatures.Command
{
    public record class DeleteCategoryByIdCommand(Guid id) :IRequest<Guid>
    {
        public class DeleteCategoryByIdCommnadHandler : IRequestHandler<DeleteCategoryByIdCommand,Guid>
        {
            private readonly InternBADBContext context;
            public DeleteCategoryByIdCommnadHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Guid> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
            {
                var category = await context.Categories.Where(c => c.ID == request.id).FirstOrDefaultAsync();
                if (category == null) return default;
                context.Categories.Add(category);
                await context.SaveChangesAsync();
                return category.ID;
            }
        }
    }
}
