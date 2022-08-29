using InternBA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.MessageFeatures.Query
{
    public class GetAllMessagesQuery : IRequest<IEnumerable<Message>>
    {
        public class GetAllMessagesQueryHanler : IRequestHandler<GetAllMessagesQuery, IEnumerable<Message>>
        {
            private readonly InternBADBContext _context;
            public GetAllMessagesQueryHanler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Message>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
            {
                return await _context.Messages.Where(message => message.DeleteAt == null).ToListAsync();
            }
        }
    }
}
