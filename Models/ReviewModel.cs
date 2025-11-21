namespace RMS.Models
{
    public class ReviewModel
    {
        public int Id { get; set; }

        public int FoodQuality { get; set; }

        public int FoodTaste { get; set; }

        public int Rating { get; set; }

        public string Remarks { get; set; } = null!;
    }
}
