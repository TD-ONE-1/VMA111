namespace RMS.Models
{
    public class ReservationRequestModel
    {
        public int Id { get; set; }

        public int ResturantId { get; set; }

        public int OfferId { get; set; }

        public int VenueId { get; set; }

        public DateTime ReservationDate { get; set; }

        public int Slot { get; set; }

        public int Members { get; set; }

        public string? Remarks { get; set; }

        public DateTime? RequestDate { get; set; }
    }
}
