using InternBA.Interfaces;
using InternBA.Models;
using System;
using System.Collections.Generic;

public class User: BaseEntity
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string? Email { get; set; }
    public string? Avater { get; set; }

    public ICollection<Comment> Comments { get; set; }  

    public ICollection<Post> Posts { get; set; }

    public ICollection<Reaction> Reactions { get; set; }

    public virtual ICollection<Room> Room { get; set; }
    public virtual ICollection<UserRoom> UserRooms { get; set; }
}
