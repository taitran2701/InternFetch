using System;

public class Room
{
	public Guid Id { get; set; }
	public Guid User1 { get; set; }
	public Guid User2 { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsD elete { get; set; }
    public virtual ICollection<User> User { get; set; }
    
}
