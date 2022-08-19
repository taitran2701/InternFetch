using InternBA.Interfaces;
using System;

public class Room: IBaseEntity
{
	public Guid Id { get; set; }
	public Guid User1 { get; set; }
	public Guid User2 { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public bool IsDelete {get; set; }
    
    public virtual ICollection<User> User { get; set; }
}
