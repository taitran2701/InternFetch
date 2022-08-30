using InternBA.ViewModels;

namespace InternBA.Features.UserFeatures.Queries
{
    public record GetUserByUserNameQuery(LoginInformation login) : IRequest<UserViewModel>
    {

    }
}
