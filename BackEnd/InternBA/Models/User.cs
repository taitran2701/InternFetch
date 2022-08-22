using InternBA.Interfaces;
using System;
using System.Collections.Generic;

public class User: BaseEntity
{
    public Guid Id { get; set; } 
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string Avater { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public DateTime? DeleteAt { get; set; }
    public virtual ICollection<Room> Room { get; set; }
}
