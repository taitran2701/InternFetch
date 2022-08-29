using InternBA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.MessageFeatures.Command
{
    public class UpdateMessageCommand : IRequest<Message>
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Content { get; set; }
        public class UpdateMessageCommandHandler : IRequestHandler<UpdateMessageCommand, Message>
        {
            private readonly InternBADBContext _context;
            public UpdateMessageCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Message> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
            {
                var message = await _context.Messages.FindAsync(request.ID);

                if (message == null)
                {
                    return default;
                }
                message.UserId = request.UserID;
                message.Content = request.Content;
                message.UpdatedDate = DateTime.UtcNow;
                return null;

                _context.Entry(message).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return message;
            }
        }
    }
}
