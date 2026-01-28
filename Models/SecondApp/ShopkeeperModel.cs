namespace RMS.Models.SecondApp
{
    public class ShopkeeperModel
    {
        public int ShopkeeperId { get; set; }

        public string ShopkeeperName { get; set; } = null!;

        public string BusinessName { get; set; } = null!;

        public int BusinessTypeId { get; set; }

        public string Address { get; set; } = null!;

        public string NTN { get; set; } = null!;

        public string CNIC { get; set; } = null!;

        public string PhoneNo { get; set; } = null!;

        public string MobileNumber { get; set; } = null!;

        public string Website { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool Status { get; set; }

        public decimal Latitude { get; set; }

        public decimal Longitude { get; set; }

        public int RatingId { get; set; }
    }
}
