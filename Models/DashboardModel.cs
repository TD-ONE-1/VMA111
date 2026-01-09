namespace RMS.Models
{
    public class DashboardModel
    {
        public int TotalReservationCount { get; set; }

        public int ConfirmedReservationCount  { get; set; }

        public int PendingReservationCount  { get; set; }

        public int CancelledReservationCount  { get; set; }

        public int TotalEventQueryCount { get; set; }

        public int ConfirmedEventQueryCount { get; set; }

        public int PendingEventQueryCount { get; set; }

        public int CancelledEventQueryCount { get; set; }

        public int ReviewsCount { get; set; }
    }
}
