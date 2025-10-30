namespace RMS.Models
{
    public class ResturantVenueModel
    {
        public int Id { get; set; }

        public int ResturantId { get; set; }

        public string Description { get; set; } = null!;

        public string Location { get; set; } = null!;

        public bool Status { get; set; }
    }
}
