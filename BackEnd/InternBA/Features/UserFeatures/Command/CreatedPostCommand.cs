using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Command
{
    public class CreatedPostCommand : IRequest<Post>
    {
        public string? Content { get; set; }

        public string? Attachment { get; set; }

        public Guid? UserID   { get; set; }

        public class CreatePostCommandHandler : IRequestHandler<CreatedPostCommand, Post>
        {
            private readonly InternBADBContext _context;

            public CreatePostCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Post> Handle(CreatedPostCommand request , CancellationToken cancellationToken)
            {
                var post = new Post();
                if(request.Content != null) { post.Content = request.Content; }
                if(request.Attachment != null) { post.Attachment = request.Attachment; }
                post.UserID = request.UserID;
                post.CreatedDate = DateTime.UtcNow;

                _context.Posts.Add(post);
                await _context.SaveChangesAsync();
                return post;

            }


        }

    }
}
