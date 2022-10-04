using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Command
{
    public class UpdateNewPostCommand : IRequest<Post>
    {
        public Guid Id { get; set; }
        public string? Attachment { get; set; }

        public class UpdateNewPostCommandHandler : IRequestHandler<UpdateNewPostCommand, Post>
        {
            private readonly InternBADBContext context;

            public UpdateNewPostCommandHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Post> Handle(UpdateNewPostCommand request, CancellationToken cancellationToken)
            {
                var post = context.Posts.Where(p=>p.ID == request.Id).FirstOrDefault();
                if (post == null) return default;
                if (request.Attachment != null)
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
