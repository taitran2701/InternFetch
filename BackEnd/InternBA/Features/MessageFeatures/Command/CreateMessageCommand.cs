using InternBA.Infrastructure.Data;
using MediatR;

namespace InternBA.Features.MessageFeatures.Command
{
    public class CreateMessageCommand : IRequest<Message>
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string content { get; set; }

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
                message.UserId = request.UserID;
                message.Content = request.content;
                message.CreatedDate = DateTime.UtcNow;

                _context.Messages.Add(message);
                _context.SaveChanges();
                return message;
            }
        }
    }
}
