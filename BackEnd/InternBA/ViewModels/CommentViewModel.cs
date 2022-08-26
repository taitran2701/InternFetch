namespace InternBA.ViewModels
{
    public class CommentViewModel
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Content { get; set; }
        public Guid ReactionID { get; set; }
        public Guid PostID { get; set; }
    }
}
