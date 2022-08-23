using InternBA.Interface;

namespace InternBA.Models
{
    public class Post : IBaseEntity
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }


        public Guid UserID { get; set; }

        public Guid Reaction { get; set; }
        public virtual ICollection<Reaction> Reactions { get; set; }

        public Guid CommentID { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }


        public Guid AttachmentID { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}
