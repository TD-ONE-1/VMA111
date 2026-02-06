namespace RMS.Models
{
    public class RestaurantCreateModel
    {
        public RestaurantDto Restaurant { get; set; }
        public List<ImageDto> Images { get; set; }
        public string? BookingTypes { get; set; }
        public string? Offers { get; set; }
        public List<BranchDto> Branches { get; set; }
        public List<SlotDto> Slots { get; set; }
    }
    public class RestaurantDto
    {
        public string? Name { get; set; }
        public string? About_Description { get; set; }
        public string? CuisineType { get; set; }
        public string? PriceRange { get; set; }
        public bool IsActive { get; set; }
    }
    public class ImageDto
    {
        public string? ImageType { get; set; }
        public string? File { get; set; } // path / filename (NOT IFormFile here)
    }
    public class BranchDto
    {
        public string? BranchName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
    }
    public class SlotDto
    {
        public string? Day { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public int Duration { get; set; }
        public int Maximum_Capacity { get; set; }
        public bool IsActive { get; set; }
    }
}
