namespace RMS.Models.SecondApp
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        public string CustomerCode { get; set; } = null!;

        public string CustName { get; set; } = null!;

        public string CustAccountCode { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string NTN { get; set; } = null!;

        public string CNIC { get; set; } = null!;

        public string PhoneNo { get; set; } = null!;

        public string MobileNo { get; set; } = null!;

        public string Email { get; set; } = null!;

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int RatingId { get; set; }

        public bool Status { get; set; }

        public int PaymentTermId { get; set; }

        public decimal Discount { get; set; }
    }
}
