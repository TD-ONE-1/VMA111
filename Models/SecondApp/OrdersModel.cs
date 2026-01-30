namespace RMS.Models.SecondApp
{
    public class OrdersModel
    {
        public int OrderId { get; set; }

        public int ShopkeeperId { get; set; }

        public int BranchId { get; set; }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal Cost { get; set; }

        public bool TaxApplicable { get; set; }

        public decimal TaxPercentage { get; set; }

        public bool IsDeliveryAddressChange { get; set; }

        public string DeliveryAddress { get; set; } = null!;

        public string ContactPerson { get; set; } = null!;

        public string DeliveryReceivedBy { get; set; } = null!;

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public string OrderStatus { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public DateTime ExpectedDeliveryDate { get; set; }

        public DateTime ConfirmDeliveryDate { get; set; }
    }
}
