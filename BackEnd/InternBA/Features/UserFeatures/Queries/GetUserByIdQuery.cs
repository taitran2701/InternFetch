using InternBA.Infrastructure.Data;
using MediatR;
using System.Linq;

namespace InternBA.Features.UserFeatures.Queries
{
    public record GetUserByIdQuery(Guid Id) : IRequest<User>;

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
            var user = context.Users.FirstOrDefault(u => u.ID == request.Id);
            if (user == null) return null;

            return user;
        }
    }
}
