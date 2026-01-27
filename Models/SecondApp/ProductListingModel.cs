namespace RMS.Models.SecondApp
{
    public class ProductListingModel
    {
        public int PLId { get; set; }

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public string CategoryType { get; set; } = null!;

        public int StockRemaining { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public bool Status { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
