namespace InternBA.Models
{
    public class Comment
    {

        public Guid ID { get; set; }

        public Guid PostID { get; set; }

        public Guid UserID { get; set; }
        public string Content { get; set; }

        public  int Reaction { get; set; }
        public ICollection<Reaction> Reactions { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }

    }
}
