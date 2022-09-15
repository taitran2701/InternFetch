using InternBA.Interfaces;
namespace InternBA.Models
{
    public class Category : BaseEntity
    {
        
        public string? Images { get; set; }
        public string? Video { get; set; }

        public Guid? PostID { get; set; }
        public Post Post { get; set; }


    }
}
