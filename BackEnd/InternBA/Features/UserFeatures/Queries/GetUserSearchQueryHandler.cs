using InternBA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.UserFeatures.Queries
{
    public class GetUserSearchQueryHandler : IRequestHandler<GetUserSearchQuery, IEnumerable<User>>
    {
        private readonly InternBADBContext _context;

        public GetUserSearchQueryHandler(InternBADBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Handle(GetUserSearchQuery request, CancellationToken cancellationToken)
        {
            var users = await _context.Users.Where(user =>
            user.Username.Contains(request.search)).ToListAsync();

            if (users == null) return null;
            return users;
        }
    }
}