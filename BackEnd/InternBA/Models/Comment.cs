using InternBA.Interfaces;
namespace InternBA.Models
{
    public class Comment : BaseEntity
    {
        public Guid? UserID { get; set; }
        public User User { get; set; }

        public string Content { get; set; }

        public Guid? ReactionID { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
        
        public Guid? PostID { get; set; }
        public Post Post { get; set; }  

    }
}
