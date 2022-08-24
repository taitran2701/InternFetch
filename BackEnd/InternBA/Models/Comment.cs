using InternBA.Interfaces;
namespace InternBA.Models
{
    public class Comment : BaseEntity
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Content { get; set; }
        public Guid ReactionID { get; set; }
        public ICollection<Reaction> Reactions { get; set; }
        
        public Guid PostID { get; set; }
        public Post Post { get; set; }  
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeleteAt { get; set; }

    }
}
