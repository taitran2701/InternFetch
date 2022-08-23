using InternBA.Infrastructure.Data;
using MediatR;

namespace InternBA.Features.RoomFeatures.Command
{
    public class CreateRoomCommand : IRequest<Room>
    {
        public Guid ID { get; set; }
        public Guid UserID1 { get; set; }
        public Guid UserID2 { get; set; }

        public class CreateRoomCommandHandler : IRequestHandler<Room>
        {
            public readonly InternBADBContext _context;

            public CreateRoomCommandHandler(InternBADBContext context)
            {
                _context = context;
            }

            public async Task<Room> Handle(Room request, CancellationToken cancellationToken)
            {
                var room = new Room()
                {
                    Id = request.Id,
                    User1 = request.User1,
                    User2 = request.User2,
                    CreatedDate = DateTime.UtcNow
                };
                
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return room;
            }
        }
    }
}
