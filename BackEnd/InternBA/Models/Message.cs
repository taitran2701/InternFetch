using InternBA.Interfaces;
using System;

public class Message: BaseEntity
{
    public Guid ID { get; set; }
    public Guid UserId { get; set; }
    public string Content { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeleteAt { get; set; }

    public Guid RoomId { get; set; }
    public Room Room { get; set; }
    
}
