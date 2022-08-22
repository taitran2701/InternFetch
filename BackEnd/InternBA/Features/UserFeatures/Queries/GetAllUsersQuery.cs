using InternBA.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.UserFeatures.Queries
{
    public class GetAllUsersQuery : IRequest<IEnumerable<User>>
    {
        public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
        {
            private readonly InternBADBContext context;

            public GetAllUsersQueryHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var users = await context.Users.ToListAsync();
                if (users == null)
                {
                    return null;
                }

                return users.AsReadOnly();
            }
        }
    }
}
