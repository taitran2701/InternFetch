using InternBA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.RoomFeatures.Command
{
    public record DeleteRoomByIdCommand(Guid id) : IRequest<Room>
    {

        public class DeleteRoomByIdCommandHandler : IRequestHandler<DeleteRoomByIdCommand, Room>
        {
            public readonly InternBADBContext _context;

            public DeleteRoomByIdCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Room> Handle(DeleteRoomByIdCommand request, CancellationToken cancellationToken)
            {
                var room = await _context.Rooms.FindAsync(request.id);
                if (room == null || room.DeleteAt != null) return default;

                room.DeleteAt = DateTime.UtcNow;
                _context.Entry(room).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return room;
            }
        }
    }
}
