
using InternBA.Interfaces;

namespace InternBA.Models
{
    public class Attachment: BaseEntity
    {

        public Guid? PostID { get; set; }
        public Post Post { get; set; }


        public Guid? CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
