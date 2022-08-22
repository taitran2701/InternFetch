namespace InternBA.ViewModels
{
    public class MessageViewModel
    {
        public Guid ID { get; set; }
        public Guid UserId { get; set; }
        public string Content { get; set; }
        public Guid RoomId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeleteAt { get; set; }
    }
}
