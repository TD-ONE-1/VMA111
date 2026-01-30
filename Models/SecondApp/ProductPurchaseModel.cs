namespace RMS.Models.SecondApp
{
    public class ProductPurchaseModel
    {
        public int ProductPurchaseId { get; set; }

        public int ShopkeeperId { get; set; }

        public int BranchId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public DateTime PODate { get; set; }

        public string PONumber { get; set; } = null!;

        public string TransactionType { get; set; } = null!;
    }
}
