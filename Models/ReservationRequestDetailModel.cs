namespace RMS.Models
{
    public class ReservationRequestDetailModel
    {
        public int Id { get; set; }

        public int ReservationRequestId { get; set; }

        public int TotalCapacity { get; set; }

        public int AvailableCapacity { get; set; }

        public string ConfirmedBy { get; set; } = null!;

        public DateTime ConfirmedOn { get; set; }
    }
}
