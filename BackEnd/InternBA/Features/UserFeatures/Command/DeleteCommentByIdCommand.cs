using InternBA.Infrastructure.Data;
using InternBA.Models;
using System.Data.Entity;

namespace InternBA.Features.UserFeatures.Command
{
    public record class DeleteCommentByIdCommand(Guid id) : IRequest<Comment>
    {
        public class DeleteCommentByIdCommandHandler : IRequestHandler<DeleteCommentByIdCommand,Comment>
        {
            private readonly InternBADBContext context;

            public DeleteCommentByIdCommandHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Comment> Handle(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
            {
                var comment = context.Comments.Where(c => c.ID == request.id).FirstOrDefault();
                if (comment == null) return default;
                comment.DeleteAt = DateTime.UtcNow;
                await context.SaveChangesAsync();
                return comment;
            }
        }
    }
}
