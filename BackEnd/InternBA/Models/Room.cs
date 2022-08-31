using InternBA.Interfaces;
using InternBA.Models;
using System;

public class Room: BaseEntity
{
	public Guid User1 { get; set; }
	public Guid User2 { get; set; }
    
    public virtual ICollection<UserRoom> UserRooms { get; set; }
}
