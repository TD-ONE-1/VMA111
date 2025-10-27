using RMS.Models;

namespace RMS.Repository.Interface
{
    public interface IJWTManagerRepository
    {
        TokenModel Authenticate(AccountModel users, int TokenTimeOut);
    }
}
