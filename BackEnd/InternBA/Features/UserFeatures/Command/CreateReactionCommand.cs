using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Command
{
    public class CreateReactionCommand : IRequest<Guid>
    {
        public string Expression { get; set; }
        public Guid PostId { get; set; }
        public Guid CommentId { get; set; }

        public class CreateReactionCommandHandler : IRequestHandler<CreateReactionCommand,Guid>
        {
            private readonly InternBADBContext _context;
            public CreateReactionCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateReactionCommand request, CancellationToken cancellationToken)
            {
                var reaction = new Reaction();
                reaction.Expression = request.Expression;
                reaction.PostID = request.PostId;    
                _context.Reactions.Add(reaction);
                await _context.SaveChangesAsync();
                return reaction.ID;
            }
        }
    }
}
