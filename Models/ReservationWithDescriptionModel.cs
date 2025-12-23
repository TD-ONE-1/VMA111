namespace RMS.Models
{
    public class ReservationWithDescriptionModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ReservationType { get; set; }

        public DateTime ReservationDate { get; set; }

        public int RestaurantId { get; set; }
        
        public string? RestaurantDescription { get; set; }

        public int BranchId { get; set; }

        public string? BranchDescription { get; set; }

        public int OfferId { get; set; }
        public string? OfferDescription { get; set; }

        public int BookingTypeId { get; set; }

        public string? BookingTypeDescription { get; set; }

        public int SlotId { get; set; }

        public string? SlotDescription { get; set; }

        public DateTime BookingDate { get; set; }

        public int Members { get; set; }

        public string Remarks { get; set; } = null!;

        public bool Status { get; set; }

        public string? phoneNo { get; set; }
    }
}
