using InternBA.Interfaces;

namespace InternBA.Models
{
    public class Reaction : BaseEntity
    {
        public string Expression { get; set; }

        public Guid? PostID { get; set; }
        public Post Post { get; set; }

        public Guid? UserId { get; set; }
        public User User { get; set; }

    }
}
