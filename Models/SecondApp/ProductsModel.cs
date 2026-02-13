namespace RMS.Models.SecondApp
{
    public class ProductsModel
    {
        public int ProductId { get; set; }

        public int BranchId { get; set; }

        public string ProductCode { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int CategoryTypeId { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; } = null!;

        public IFormFile? Image { get; set; } = null!;

        public bool Status { get; set; }

        public decimal TDDiscount { get; set; }

        public decimal Cost { get; set; }

        public bool TaxAppilcable { get; set; }

        public int TaxPercentage { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
