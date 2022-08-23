namespace InternBA.Interface
{
    public interface IBaseEntity
    {
        public bool? IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
