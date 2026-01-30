namespace RMS.Models.SecondApp
{
    public class ShopBranchModel
    {
        public int BranchID { get; set; }

        public int ShopkeeperId { get; set; }

        public string BranchName { get; set; } = null!;

        public string PhoneNo { get; set; } = null!;

        public string MobileNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public bool Status { get; set; }
    }
}
