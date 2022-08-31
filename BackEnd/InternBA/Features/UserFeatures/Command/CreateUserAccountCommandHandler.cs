using InternBA.Infrastructure.Data;
using InternBA.Models;

namespace InternBA.Features.UserFeatures.Command
{
    public class CreateUserAccountCommandHandler : IRequestHandler<CreateUserAccountCommand, Guid>
    {
        private readonly InternBADBContext _context;

        public CreateUserAccountCommandHandler(InternBADBContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var user = new User();
            user.Username = request.userAccountViewModel.Username;
            user.Password = request.userAccountViewModel.Password;
            user.CreatedDate = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user.ID;
        }
    }
}
