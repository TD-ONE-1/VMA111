namespace RMS.Models
{
    public class ReservationRequestModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int ReservationType { get; set; }

        public DateTime ReservationDate { get; set; }

        public string ReservationName { get; set; } = null!;

        public string PhoneNo { get; set; } = null!;

        public int RestaurantId { get; set; }

        public int BranchId { get; set; }

        public int OfferId { get; set; }

        public int BookingTypeId { get; set; }

        public int SlotId { get; set; }

        public int Members { get; set; }

        public string Remarks { get; set; } = null!;

        public int Status { get; set; }

        public bool IsArrived { get; set; }
    }
}
