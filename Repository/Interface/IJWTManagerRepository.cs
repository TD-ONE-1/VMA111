using RMS.Models;

namespace RMS.Repository.Interface
{
    public interface IJWTManagerRepository
    {
        TokenModel Authenticate(AccountModel users, int TokenTimeOut);

        TokenJVModel AuthenticateJV(AccountJVModel users, int TokenTimeOut);
    }
}
