namespace RMS.Models
{
    public class TokenJVModel
    {
        public TokenJVModel()
        {
            userDetail = new AccountJVModel();
        }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public AccountJVModel userDetail { get; set; }
    }
}
