using InternBA.Infrastructure.Data;
using InternBA.ViewModels;

namespace InternBA.Features.UserFeatures.Queries
{
    public class GetUserNameQueryHandler : IRequestHandler<GetUserByUserNameQuery, UserViewModel>
    {
        private readonly InternBADBContext _context;
        public GetUserNameQueryHandler(InternBADBContext context)
        {
            _context = context;
        }

        public Task<UserViewModel> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var user = _context.Users.Where(u => 
            u.Username == request.login.Username && 
            u.Password == request.login.Password).FirstOrDefault();

            if (user == null) return null;
            var result = Task<UserViewModel>.Factory.StartNew(() =>
            {
                return new UserViewModel()
                {
                    Id = user.ID,
                    Username = user.Username,
                    Email = user.Email,
                    Avater = user.Avater,
                    Password = user.Password
                };
            });
            return result;
        }
    }
}
