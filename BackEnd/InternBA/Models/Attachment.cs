namespace InternBA.Models
{
    public enum AttachmentTypes
    {
        Images,
        Videos
    }
    public class Attachment
    {
        public int PostID { get; set; }
        public int Type { get; set; }

        public AttachmentTypes AttachmentType { get; set; }
    }
}
