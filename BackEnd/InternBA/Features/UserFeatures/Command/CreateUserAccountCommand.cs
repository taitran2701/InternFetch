using InternBA.Infrastructure.Data;
using InternBA.Models;
using InternBA.ViewModels;
using MediatR;

namespace InternBA.Features.UserFeatures.Command
{
    public record CreateUserAccountCommand(UserAccountViewModel userAccountViewModel) : IRequest<Guid>
    {

        
    }
}
