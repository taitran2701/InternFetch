using InternBA.Interface;
namespace InternBA.Models
{
    public class Category : IBaseEntity
    {
        public Guid ID { get; set; }
        public string Images { get; set; }
        public string Video { get; set; }

        public Attachment Attachment { get; set; }
        public bool? IsDeleted { get ; set ; }
        public DateTime CreatedDate { get ; set; }
        public DateTime? UpdatedDate { get ; set; }
    }
}
