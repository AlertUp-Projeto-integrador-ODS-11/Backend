using AlertUp.Model;

namespace AlertUp.Security;

public interface IAuthService
{
    Task<UserLogin?> Autenticar(UserLogin userLogin);
}