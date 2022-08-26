using InternBA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.UserFeatures.Command
{
    public record DeleteUserByIdCommand(Guid id) : IRequest<User>
    {
        public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, User>
        {
            private readonly InternBADBContext context;

            public DeleteUserByIdCommandHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<User> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
            {
                var user = await context.Users.Where(u => u.ID == request.id).FirstOrDefaultAsync();
                if (user == null) return default;
                context.Users.Remove(user);
                await context.SaveChangesAsync();

                return user;
            }
        }
    }
}
