using InternBA.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InternBA.Features.UserFeatures.Queries
{
    public class GetUserFriendQueryHandler : IRequestHandler<GetUserFriendQuery, IEnumerable<User>>
    {
        private readonly InternBADBContext _context;

        public GetUserFriendQueryHandler(InternBADBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> Handle(GetUserFriendQuery request, CancellationToken cancellationToken)
        {
            var user = _context.Users.Where(user =>
            user.Username == request.username).FirstOrDefault();

            var rooms = _context.UserRoom.Include(userRoom => userRoom.Room)
                .ToList();

            List<User> friends = new List<User>();
            foreach (var item in rooms)
            {
                if(user.ID == item.Room.User1 || user.ID == item.Room.User2)
                {
                    Console.WriteLine(user.Username);
                    friends.Add(user);
                }
            }

            IEnumerable<User> friendResult = friends.Distinct<User>();
            return friendResult;
        }
    }
}