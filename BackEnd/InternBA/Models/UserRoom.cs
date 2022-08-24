using InternBA.Interfaces;

namespace InternBA.Models
{
    public class UserRoom : BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid RoomId { get; set; }
        public Room Room { get; set; }
    }
}
