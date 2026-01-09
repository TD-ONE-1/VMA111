namespace RMS.Models
{
    public class vwReservationModel
    {
        public int id { get; set; }

        public DateOnly? ReservationDate { get; set; }

        public string UserName { get; set; } = null!;

        public string BranchName { get; set; } = null!;

        public string Offer { get; set; } = null!;

        public string BookingType { get; set; } = null!;

        public string? Slot { get; set; }

        public int Members { get; set; }

        public string Remarks { get; set; } = null!;

        public int Status { get; set; }
    }
}
