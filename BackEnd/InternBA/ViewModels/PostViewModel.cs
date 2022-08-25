namespace InternBA.ViewModels
{
    public class PostViewModel
    {
        public Guid ID { get; set; }
        public string Content { get; set; }
        public Guid? Reaction { get; set; }
        public Guid? CommentID { get; set; }
        public Guid? AttachmentID { get; set; }

    }
}
