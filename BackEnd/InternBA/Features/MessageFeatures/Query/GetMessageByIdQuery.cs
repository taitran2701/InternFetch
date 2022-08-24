using InternBA.Infrastructure.Data;
using MediatR;

namespace InternBA.Features.MessageFeatures.Query
{
    public class GetMessageByIdQuery : IRequest<Message>
    {
        public Guid ID { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetMessageByIdQuery, Message>
        {
            private readonly InternBADBContext _context;
            public GetUserByIdQueryHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Message> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
            {
                var message = await _context.Messages.FindAsync(request.ID);
                if (message == null || message.DeleteAt != null) return default;

                return message;
            }
        }
    }
}
