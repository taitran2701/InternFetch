using InternBA.Features.MessageFeatures.Command;
using InternBA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.RoomFeatures.Command
{
    public class UpdateRoomCommand : IRequest<Room>
    {
        public Guid ID { get; set; }
        public Guid UserID1 { get; set; }
        public Guid UserID2 { get; set; }

        public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Room>
        {
            public readonly InternBADBContext _context;
            public UpdateRoomCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Room> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
            {
                var room = await _context.Rooms.FindAsync(request.ID);

                if (room == null)
                {
                    return default;
                }

                room.User1 = request.UserID1;
                room.User2 = request.UserID2;
                room.UpdatedDate = DateTime.UtcNow;

                _context.Entry(room).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return room;
            }
        }
    }
}
