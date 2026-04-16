namespace RMS.Models
{
    public class vwProductModel
    {
        public int ProductId { get; set; }

        public int BranchId { get; set; }

        public string BranchName { get; set; } = null!;

        public string ProductCode { get; set; } = null!;

        public string Name { get; set; } = null!;

        public decimal Price { get; set; }

        public int CategoryTypeId { get; set; }

        public string CategoryType { get; set; } = null!;

        public int Stock { get; set; }

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public bool Status { get; set; }

        public decimal TDDiscount { get; set; }

        public decimal Cost { get; set; }

        public bool TaxAppilcable { get; set; }

        public int TaxPercentage { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
