using InternBA.Interfaces;
namespace InternBA.Models
{
    public class Category : BaseEntity
    {
        public Guid ID { get; set; }
        public string Images { get; set; }
        public string Video { get; set; }
        public Guid AttachmentID { get; set; }
        public Attachment Attachment { get; set; }
    }
}
