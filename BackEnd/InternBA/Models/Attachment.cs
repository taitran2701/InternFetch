namespace InternBA.Models
{
    public class Attachment
    {
        public Guid ID { get; set; }
        public Guid PostID { get; set; }
        public Post Post { get; set; }
        public int Category { get; set; }
        public ICollection<Category> Categories { get; set; }

    }
}
