using RMS.Entity;

namespace RMS.Models
{
    public class R_OfferModel
    {
        public int Id { get; set; }

        public int RestaurantId { get; set; }

        public int BranchId { get; set; }

        public string Offer { get; set; } = null!;

        public bool IsActive { get; set; }
    }
}
