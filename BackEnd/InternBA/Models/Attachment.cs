using InternBA.Interface;
using System.ComponentModel.DataAnnotations.Schema;
namespace InternBA.Models
{

    
    public class Attachment : IDelete, ICreatedDate, IUpdatedDate
    {
        public Guid ID { get; set; }
        public Guid PostID { get; set; }
        public int Type { get; set; }

        public ICollection <Type>? Types { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }  
    }
}
