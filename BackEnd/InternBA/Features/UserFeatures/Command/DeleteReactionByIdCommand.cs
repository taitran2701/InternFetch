using InternBA.Infrastructure.Data;
using System.Data.Entity;

namespace InternBA.Features.UserFeatures.Command
{
    public record class DeleteReactionByIdCommand(Guid id) : IRequest<Guid>
    {
        public class DeleteReactionByIdCommandHandler : IRequestHandler<DeleteReactionByIdCommand,Guid>
        {
            private readonly InternBADBContext context;

            public DeleteReactionByIdCommandHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Guid> Handle(DeleteReactionByIdCommand request, CancellationToken cancellationToken)
            {
                var reaction = await context.Reactions.Where(r => r.ID == request.id).FirstOrDefaultAsync();
                if (reaction == null) return default;
                context.Reactions.Remove(reaction);
                await context.SaveChangesAsync();
                return reaction.ID;
            }
        }
    }
}
