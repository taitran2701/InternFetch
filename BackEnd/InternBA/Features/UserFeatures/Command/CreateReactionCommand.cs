using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Command
{
    public class CreateReactionCommand : IRequest<Reaction>
    {
        public string Expression { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }

        public class CreateReactionCommandHandler : IRequestHandler<CreateReactionCommand,Reaction>
        {
            private readonly InternBADBContext _context;
            public CreateReactionCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Reaction> Handle(CreateReactionCommand request, CancellationToken cancellationToken)
            {
                var reaction = new Reaction();
                reaction.Expression = request.Expression;
                reaction.PostID = request.PostId; 
                reaction.UserId = request.UserId;
                _context.Reactions.Add(reaction);
                await _context.SaveChangesAsync();
                return reaction;
            }
        }
    }
}
