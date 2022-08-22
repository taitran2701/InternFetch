namespace InternBA.Interfaces
{
    public interface BaseEntity
    {
        public DateTime? DeleteAt { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
