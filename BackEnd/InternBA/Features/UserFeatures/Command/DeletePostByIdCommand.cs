using InternBA.Infrastructure.Data;
using InternBA.Models;
using System.Data.Entity;

namespace InternBA.Features.UserFeatures.Command
{
    public record class DeletePostByIdCommand(Guid id) : IRequest<Post>

    {
        public class DeletePostByIdCommandHandler : IRequestHandler<DeletePostByIdCommand,Post>
        {
            private readonly InternBADBContext context;

            public DeletePostByIdCommandHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Post> Handle(DeletePostByIdCommand request, CancellationToken cancellationToken)
            {

                var post = context.Posts.Where(p => p.ID == request.id).FirstOrDefault();
                if (post == null) return default;
                post.DeleteAt = DateTime.UtcNow;
                await context.SaveChangesAsync();   
                return post;
            }            
        }
    }
}
