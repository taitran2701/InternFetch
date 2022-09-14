using InternBA.Infrastructure.Data;

namespace InternBA.Features.UserFeatures.Command
{
    public class UpdateCategoryCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }    
        public string? Image { get; set; }
        public string?  Video { get; set; }

        public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand,Guid>
        {
            private readonly InternBADBContext context;
            public UpdateCategoryCommandHandler(InternBADBContext context)
            {
               this.context = context;
            }

            public async Task<Guid> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = context.Categories.Where(c=>c.ID == request.Id).FirstOrDefault();
                if (category == null) return default;
                category.Images = request.Image;
                category.Video = request.Video;
                category.UpdatedDate = DateTime.UtcNow;
                await context.SaveChangesAsync();
                return category.ID;
            }
        }
    }
}
