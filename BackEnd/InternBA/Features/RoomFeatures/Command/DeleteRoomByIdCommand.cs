using InternBA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.RoomFeatures.Command
{
    public class DeleteRoomByIdCommand : IRequest<Room>
    {
        public Guid ID { get; set; }

        public class DeleteRoomByIdCommandHandler : IRequestHandler<DeleteRoomByIdCommand, Room>
        {
            public readonly InternBADBContext _context;

            public DeleteRoomByIdCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Room> Handle(DeleteRoomByIdCommand request, CancellationToken cancellationToken)
            {
                var room = await _context.Rooms.FindAsync(request.ID);
                if (room == null || room.DeleteAt != null) return default;

                room.DeleteAt = DateTime.UtcNow;
                _context.Entry(room).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return room;
            }
        }
    }
}
