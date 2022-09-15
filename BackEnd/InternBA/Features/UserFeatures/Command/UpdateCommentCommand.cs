using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Command
{
    public class UpdateCommentCommand : IRequest<Comment>
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, Comment>
        {
            private readonly InternBADBContext context;

            public UpdateCommentHandler(InternBADBContext context)
            {
                this.context = context;
            }


            public async Task<Comment> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
            {
                var comment = context.Comments.Where(c=> c.ID == request.Id).FirstOrDefault();
                if (comment == null) return default;
                comment.Content = request.Content;
                comment.UpdatedDate = DateTime.UtcNow;
                await context.SaveChangesAsync();
                return comment;
            }
        }
    }
}
