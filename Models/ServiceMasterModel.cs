namespace RMS.Models
{
    public class ServiceMasterModel
    {
        public int Id { get; set; }

        public string ServiceName { get; set; } = null!;

        public int Status { get; set; }

        public bool IsActive { get; set; }
    }
}
