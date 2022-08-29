using InternBA.Infrastructure.Data;
using MediatR;
using System.Linq;

namespace InternBA.Features.UserFeatures.Queries
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public Guid Id { get; set; }
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
                var user = context.Users.Where(u => u.ID == request.Id).FirstOrDefault();
                if (user == null) return null;
                foreach (var room in user.UserRooms)
                {
                    Console.WriteLine($"------- {room.User}");
                }
                return user;
            }
            public Guid ToGuid(int value)
            {
                byte[] bytes = new byte[16];
                BitConverter.GetBytes(value).CopyTo(bytes, 0);
                return new Guid(bytes);
            }
        }
    }
}
