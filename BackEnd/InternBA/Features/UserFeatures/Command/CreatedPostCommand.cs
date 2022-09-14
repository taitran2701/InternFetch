using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Command
{
    public class CreatedPostCommand : IRequest<Guid>
    {
        public string Content { get; set; }

        public Guid? UserID   { get; set; }

        public class CreatePostCommandHandler : IRequestHandler<CreatedPostCommand, Guid>
        {
            private readonly InternBADBContext _context;

            public CreatePostCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Guid> Handle(CreatedPostCommand request , CancellationToken cancellationToken)
            {
                var post = new Post();
                post.Content = request.Content;
                post.UserID = request.UserID;
                post.CreatedDate = DateTime.UtcNow;

                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                return post.ID;

            }


        }

    }
}
