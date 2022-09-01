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

            var rooms = _context.Rooms.Where(room => room.User2 == user.ID || room.User1 == user.ID).ToList();
            List<Guid> friends = new List<Guid>();
            foreach (var item in rooms)
            {
                if (user.ID == item.User1)
                {
                    friends.Add(item.User2);
                }
                else
                {
                    friends.Add(item.User1);
                }
            }
            //var rooms = _context.UserRoom.Include(userRoom => userRoom.Room)
            //    .ToList();

            //List<Guid> friends = new List<Guid>();
            //foreach (var item in rooms)
            //{
            //    if(user.ID == item.Room.User1)
            //    {
            //        Console.WriteLine(user.Username);
            //        friends.Add(item.Room.User2);
            //    }
            //    else if (user.ID == item.Room.User2)
            //    {
            //        friends.Add(item.Room.User2);
            //    }
            //    else
            //    {
            //        continue;
            //    }
            //}

            
            List<User> friendlList = new List<User>();
            foreach (var item in friends)
            {
                friendlList.Add(_context.Users.Where(user => user.ID == item).FirstOrDefault());
            }
            return friendlList;
        }
    }
}