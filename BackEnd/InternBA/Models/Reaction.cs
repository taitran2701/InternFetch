namespace InternBA.Models
{
    public class Reaction
    {
        public Guid ID { get; set; } 
        public int UserID { get; set; }
        public int PostID { get; set; }
        public int Type { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }

        
    }
}
