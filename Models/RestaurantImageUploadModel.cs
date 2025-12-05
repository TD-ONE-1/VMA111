namespace RMS.Models
{
    public class RestaurantImageUploadModel
    {
        public int RestaurantId { get; set; }
        public IFormFile? Logo { get; set; }
        public IFormFile? Banner { get; set; }
        public List<IFormFile>? Gallery { get; set; }
    }
}
