using InternBA.Infrastructure.Data;
using MediatR;

namespace InternBA.Features.MessageFeatures.Query
{
    public class GetUserByIdQuery : IRequest<Message>
    {
        public Guid ID { get; set; }

        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, Message>
        {
            private readonly InternBADBContext _context;
            public GetUserByIdQueryHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Message> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                var message = await _context.Messages.FindAsync(request.ID);
                if (message == null || message.DeleteAt != null) return default;

                return message;
            }
        }
    }
}
