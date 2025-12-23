namespace RMS.Models
{
    public class PackageModel
    {
        public int Id { get; set; }

        public string PkgName { get; set; } = null!;

        public int MinCapacity { get; set; }

        public int MaxCapacity { get; set; }

        public decimal Price { get; set; }

        public int PkgServiceId { get; set; }

        public int Status { get; set; }

        public bool IsActive { get; set; }
    }
}
