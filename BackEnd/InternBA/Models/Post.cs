namespace InternBA.Models
{
    public class Post
    {
        public Guid ID { get; set; }
        public int UserID { get; set; }
        public int Attachment { get; set; }
        public int Reaction { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate {get;set;}
        public DateTime UpdatedDate {get;set;}

        public ICollection<Reaction> Reactions { get; set; }
        public ICollection<Comment> Comments { get; set; }        
        public ICollection<Attachment> Attachments { get; set; }
    }
}
