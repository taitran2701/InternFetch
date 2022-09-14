using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Command
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string? Image { get; set; }
        public string? Video { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand,Guid>
        {
            private readonly InternBADBContext _context;

            public CreateCategoryCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = new Category();
                category.Images = request.Image;
                category.Video = request.Video;
                category.CreatedDate = DateTime.UtcNow;
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return category.ID;
            }
        }
    }
}
