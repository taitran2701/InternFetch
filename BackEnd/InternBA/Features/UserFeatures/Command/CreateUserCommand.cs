using InternBA.Infrastructure.Data;
using InternBA.Models;
using MediatR;

namespace InternBA.Features.UserFeatures.Command
{
    public class CreateUserCommand : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avater { get; set; }
        public Guid RoomID { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
        {
            private readonly InternBADBContext _context;

            public CreateUserCommandHandler(InternBADBContext context)
            {
                _context = context;
            }
            public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User();
                user.Username = request.Username;
                user.Password = request.Password;
                user.Email = request.Email;
                user.Avater = request.Avater;
                user.CreatedDate = DateTime.UtcNow;
                user.UserRooms = new List<UserRoom>
                {
                    new UserRoom()
                    {
                        RoomId = request.RoomID
                    }
                };
                
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
        }
    }
}
