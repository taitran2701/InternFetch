using InternBA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.RoomFeatures.Query
{
    public record GetRoomByIdQuery(Guid id) : IRequest<Room>
    {
        public class GetAllMessagesQueryHanler : IRequestHandler<GetRoomByIdQuery, Room>
        {
            private readonly InternBADBContext _context;

            public GetAllMessagesQueryHanler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Room> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
            {
                var room = await _context.Rooms.FindAsync(request.id);
                if (room == null) return default;

                return room;
            }
        }
    }
}
