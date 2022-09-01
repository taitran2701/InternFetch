using InternBA.Infrastructure.Data;
using InternBA.ViewModels;
using MediatR;

namespace InternBA.Features.UserFeatures.Command
{
    public record UpdateUserPasswordCommand(UserFogotPasswordViewModel userFogotPasswordViewModel) : IRequest<Guid>
    {
        
    }
}
