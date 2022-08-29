using InternBA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.UserFeatures.Command
{
    public class DeleteUserByIdCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, Guid>
        {
            private readonly InternBADBContext context;

            public DeleteUserByIdCommandHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<Guid> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
            {
                var user = await context.Users.Where(u => u.ID == request.Id).FirstOrDefaultAsync();
                if (user == null) return default;
                context.Users.Remove(user);
                await context.SaveChangesAsync();
                return user.ID;
            }
        }
    }
}
