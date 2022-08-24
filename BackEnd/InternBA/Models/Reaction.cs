using InternBA.Interfaces;

namespace InternBA.Models
{
    public class Reaction : BaseEntity
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Expression { get; set; }
        public DateTime? DeleteAt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public Guid PostID { get; set; }
        public Post Post { get; set; }

        public Guid CommentID { get; set; }
        public Comment Comment { get; set; }

    }
}
