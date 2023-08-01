using ERPBE.Controllers;

namespace ERPBE
{
    public interface IJWTAuthenticationManager
    {
        Authentication Authenticate(string username, string password);
    }
}
