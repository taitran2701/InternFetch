using InternBA.Interface;
namespace InternBA.Models
{
    public class Reaction : IDelete, ICreatedDate, IUpdatedDate
    {
        public Guid ID { get; set; } 
        public Guid UserID { get; set; }
        public Guid PostID { get; set; }
        public int? Type { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsDeleted { get; set; }

        
    }
}
