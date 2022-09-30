using InternBA.Infrastructure.Data;
using InternBA.Models;
using System.Data.Entity;

namespace InternBA.Features.UserFeatures.Command
{
    public record class DeleteReactionByIdCommand(Guid id) : IRequest<Reaction>
    {
        public class DeleteReactionByIdCommandHandler : IRequestHandler<DeleteReactionByIdCommand,Reaction>
        {
            private readonly InternBADBContext context;

            public DeleteReactionByIdCommandHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Reaction> Handle(DeleteReactionByIdCommand request, CancellationToken cancellationToken)
            {
                var reaction =  context.Reactions.Where(r => r.ID == request.id).FirstOrDefault();
                if (reaction == null) return default;
                context.Reactions.Remove(reaction);
                await context.SaveChangesAsync();
                return reaction;
            }
        }
    }
}
