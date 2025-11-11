namespace RMS.Models
{
    public class R_BookingTypeModel
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        public int BranchId { get; set; }

        public string Name { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
