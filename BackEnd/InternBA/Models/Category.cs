using InternBA.Interfaces;
namespace InternBA.Models
{
    public class Category : BaseEntity
    {
        
        public string Images { get; set; }
        public string Video { get; set; }

        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
