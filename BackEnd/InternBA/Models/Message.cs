using InternBA.Interfaces;
using System;

public class Message: BaseEntity
{
    public Guid UserId { get; set; }
    public string Content { get; set; }

    public Guid RoomId { get; set; }
    public Room Room { get; set; }
    
}
