using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Command
{
    public class CreateCommentCommand : IRequest<Guid>
    {
        public string Content { get; set; }
        public Guid? UserID { get; set; }
        public Guid? PostID { get; set; }


        public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Guid>
        {
            private readonly InternBADBContext _context;

            public CreateCommentCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
            {
                var comment = new Comment();
                comment.Content = request.Content;
                comment.UserID = request.UserID;
                comment.PostID = request.PostID;
                comment.CreatedDate = DateTime.UtcNow;

                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();
                return comment.ID;
            
            }
        }
    }
}
