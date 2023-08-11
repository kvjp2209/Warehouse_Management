namespace Web_Api.Data
{
    public class Auditable
    {
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; } = null!;
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
