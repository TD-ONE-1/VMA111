namespace RMS.Models
{
    public class R_BranchModel
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
