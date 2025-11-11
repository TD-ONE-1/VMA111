namespace RMS.Models
{
    public class R_SlotModel
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        public int BranchId { get; set; }

        public TimeOnly StartTime { get; set; }

        public TimeOnly EndTime { get; set; }

        public bool IsActive { get; set; }
    }
}
