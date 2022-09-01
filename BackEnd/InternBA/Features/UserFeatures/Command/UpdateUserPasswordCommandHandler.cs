using InternBA.Infrastructure.Data;

namespace InternBA.Features.UserFeatures.Command
{
    public class UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommand, Guid>
    {
        private readonly InternBADBContext context;
        public UpdateUserPasswordCommandHandler(InternBADBContext context)
        {
            this.context = context;
        }

        public async Task<Guid> Handle(UpdateUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = context.Users.Where(u => u.Username == request.userFogotPasswordViewModel.Username).FirstOrDefault();

            if (user == null) return default;

            user.Password = request.userFogotPasswordViewModel.Password;
            user.UpdatedDate = DateTime.UtcNow;
            await context.SaveChangesAsync();
            return user.ID;
        }
    }
}
