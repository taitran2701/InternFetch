using InternBA.Infrastructure.Data;

namespace InternBA.Features.UserFeatures.Command
{
    public class UpdateReactionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Expression { get; set; }
        public Guid? PostID { get; set; }
        public Guid? CommentID { get; set; }


        public class UpdateReactionCommandHandler : IRequestHandler<UpdateReactionCommand, Guid>
        {
            private readonly InternBADBContext context;

            public UpdateReactionCommandHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Guid> Handle(UpdateReactionCommand request, CancellationToken cancellationToken)
            {
                var reaction = context.Reactions.Where(r => r.ID == request.Id).FirstOrDefault();
                if (reaction == null) return default;
                reaction.Expression = request.Expression;
                await context.SaveChangesAsync();
                return reaction.ID;
            }
        }


    }
}
