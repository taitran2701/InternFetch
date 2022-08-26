using InternBA.Infrastructure.Data;
using MediatR;

namespace InternBA.Features.MessageFeatures.Command
{
    public class CreateMessageCommandHandler : IRequestHandler<CreateMessageCommand, Message>
    {
        private readonly InternBADBContext _context;
        public CreateMessageCommandHandler(InternBADBContext context)
        {
            _context = context;
        }

        public async Task<Message> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
        {
            var message = new Message();
            message.ID = request.ID;
            message.UserId = request.UserId;
            message.Content = request.Content;
            message.RoomId = request.RoomId;
            message.CreatedDate = DateTime.UtcNow;

            _context.Messages.Add(message);
            _context.SaveChanges();
            return message;
        }
    }
}
