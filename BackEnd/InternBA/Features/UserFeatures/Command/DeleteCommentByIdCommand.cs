using InternBA.Infrastructure.Data;
using System.Data.Entity;

namespace InternBA.Features.UserFeatures.Command
{
    public record class DeleteCommentByIdCommand(Guid id) : IRequest<Guid>
    {
        public class DeleteCommentByIdCommandHandler : IRequestHandler<DeleteCommentByIdCommand,Guid>
        {
            private readonly InternBADBContext context;

            public DeleteCommentByIdCommandHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async  Task<Guid> Handle(DeleteCommentByIdCommand request, CancellationToken cancellationToken)
            {
                var comment = await context.Comments.Where(c => c.ID == request.id).FirstOrDefaultAsync();
                if (comment == null) return default;
                context.Comments.Remove(comment);
                await context.SaveChangesAsync();
                return comment.ID;
            }
        }
    }
}
