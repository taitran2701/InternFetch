using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Command
{
    public class CreateCategoryCommand : IRequest<Category>
    {
        public string? Image { get; set; }
        public string? Video { get; set; }
        public Guid PostID { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand,Category>
        {
            private readonly InternBADBContext _context;

            public CreateCategoryCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Category> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = new Category();
                category.Images = request.Image;
                category.Video = request.Video;
                category.PostID = request.PostID;
                category.CreatedDate = DateTime.UtcNow;

                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return category;
            }
        }
    }
}
