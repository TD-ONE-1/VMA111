namespace RMS.Models
{
    public class TokenModel
    {
        public TokenModel()
        {
            userDetail = new AccountModel();
        }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public AccountModel userDetail { get; set; }
    }
}
