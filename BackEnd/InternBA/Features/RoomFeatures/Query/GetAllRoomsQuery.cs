using InternBA.Features.MessageFeatures.Query;
using InternBA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.RoomFeatures.Query
{
    public class GetAllRoomsQuery : IRequest<IEnumerable<Room>>
    {
        public class GetAllMessagesQueryHanler : IRequestHandler<GetAllRoomsQuery, IEnumerable<Room>>
        {
            private readonly InternBADBContext _context;
            public GetAllMessagesQueryHanler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<Room>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
            {
                return await _context.Rooms.Where(room => room.DeleteAt == null).ToListAsync();
            }
        }
    }
}
