namespace RMS.Models
{
    public class RestaurantImageUploadModel
    {
        public int RestaurantId { get; set; }
        public string? Logo { get; set; }
        public string? Banner { get; set; }
        public List<string>? Gallery { get; set; }
    }
}
