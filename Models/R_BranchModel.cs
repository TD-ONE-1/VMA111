namespace RMS.Models
{
    public class R_BranchModel
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        public string Name { get; set; } = null!;

        public string Location { get; set; } = null!;

        public int Capacity { get; set; }

        public bool IsActive { get; set; }
    }
}
