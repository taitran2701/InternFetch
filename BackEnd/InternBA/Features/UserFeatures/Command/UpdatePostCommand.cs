using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Command
{
    public class UpdatePostCommand : IRequest<Post>
    {
        public Guid Id { get; set; }
        public string? Content { get; set; }

        public string? Attachment { get; set; }

        public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Post>
            {
            private readonly InternBADBContext context;
            public UpdatePostCommandHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Post> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
            {
                var post = context.Posts.Where(p => p.ID == request.Id).FirstOrDefault();
                if (post == null) return default;
                if (request.Content != null)  {
                    post.Content = request.Content;
                }
                else if (request.Attachment != null)
                {
                    post.Attachment = request.Attachment;
                }
                post.UpdatedDate = DateTime.UtcNow;
                await context.SaveChangesAsync();
                return post;
            }
        }
    }
}
