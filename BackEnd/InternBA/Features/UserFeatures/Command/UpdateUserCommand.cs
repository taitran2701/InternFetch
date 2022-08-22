using MediatR;

namespace InternBA.Features.UserFeatures.Command
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Avater { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Guid>
        {
            private readonly InternBADBContext context;
            public UpdateUserCommandHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Guid> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = context.Users.Where(u => u.Id == request.Id).FirstOrDefault();
                if (user == null) return default;
                user.Username = request.Username;
                user.Password = request.Password;
                user.Avater = request.Avater;
                user.Email = request.Email;
                await context.SaveChangesAsync();
                return user.Id;
            }
        }
    }
}
