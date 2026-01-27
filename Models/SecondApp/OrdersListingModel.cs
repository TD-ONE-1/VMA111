namespace RMS.Models.SecondApp
{
    public class OrdersListingModel
    {
        public int OLId { get; set; }

        public string Name { get; set; } = null!;

        public string CategoryType { get; set; } = null!;

        public int Quantity { get; set; }

        public string? Description { get; set; }

        public string? Image { get; set; }

        public decimal OrderAmount { get; set; }

        public bool Status { get; set; }

        public DateTime OrderDate { get; set; }
    }
}
