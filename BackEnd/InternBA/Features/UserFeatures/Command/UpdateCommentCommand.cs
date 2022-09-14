using InternBA.Infrastructure.Data;

namespace InternBA.Features.UserFeatures.Command
{
    public class UpdateCommentCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid? UserId { get; set; }
        public string Content { get; set; }
        public Guid? ReactionID { get; set; }
        public Guid? PostID { get; set; }

        public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, Guid>
        {
            private readonly InternBADBContext context;

            public UpdateCommentHandler(InternBADBContext context)
            {
                this.context = context;
            }


            public async Task<Guid> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
            {
                var comment = context.Comments.Where(c=> c.ID == request.Id).FirstOrDefault();
                if (comment == null) return default;
                comment.Content = request.Content;
                comment.UpdatedDate = DateTime.UtcNow;
                await context.SaveChangesAsync();
                return comment.ID;
            }
        }
    }
}
