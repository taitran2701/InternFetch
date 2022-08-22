using InternBA.Infrastructure.Data;
using MediatR;

namespace InternBA.Features.UserFeatures.Command
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avater { get; set; }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
        {
            private readonly InternBADBContext context;

            public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var user = new User();
                user.Username = request.Username;
                user.Password = request.Password;
                user.Email = request.Email;
                user.Avater = request.Avater;
                user.CreatedDate = DateTime.UtcNow;
                user.UpdatedDate = DateTime.UtcNow;
                user.DeleteAt = DateTime.UtcNow;

                context.Users.Add(user);
                await context.SaveChangesAsync();

                return user.Id;
            }
        }
    }
}
