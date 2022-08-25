namespace InternBA.ViewModels
{
    public class ReactionViewModel
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public string Expression { get; set; }
        public Guid PostID { get; set; }
        public Guid CommentID { get; set; }
    }
}
