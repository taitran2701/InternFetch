namespace InternBA.Interfaces
{
    public interface IBaseEntity
    {
        public bool IsDelete { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
