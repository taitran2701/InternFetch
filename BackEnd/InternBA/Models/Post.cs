using InternBA.Interface;
namespace InternBA.Models
{
    public class Post : IDelete, ICreatedDate, IUpdatedDate
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }

        public int Attachment { get; set; }
        public ICollection<Attachment> Attachments { get; set; }

        public int Reaction { get; set; }
        public ICollection<Reaction> Reactions { get; set; }

        public string Content { get; set; }
        public DateTime CreatedDate {get;set;}
        public DateTime UpdatedDate {get;set;}

        public string? CommentID { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public bool IsDeleted { get; set; }

    }
}
