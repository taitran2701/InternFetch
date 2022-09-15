using InternBA.Interfaces;

namespace InternBA.Models
{
    public class Post : BaseEntity
    {
        public string Content { get; set; }       

        public Guid? UserID { get; set; }
        public User User { get; set; }

        public Guid? Reaction { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }


        public Guid? CategoryID { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
