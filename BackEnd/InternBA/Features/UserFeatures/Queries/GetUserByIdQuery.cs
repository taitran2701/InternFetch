using InternBA.Infrastructure.Data;
using MediatR;
using System.Linq;

namespace InternBA.Features.UserFeatures.Queries
{
    public record class GetUserByIdQuery(Guid id) : IRequest<User>
    {
        public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
        {
            private readonly InternBADBContext context;
            public GetUserByIdQueryHandler(InternBADBContext context)
            {
                this.context = context;
            }

            public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
            {
                //Todo - XuanLoi: can be error
                var user = context.Users.Where(u => u.ID == request.id).FirstOrDefault();
                if (user == null) return null;

                return user;
            }
        }
    }
}
