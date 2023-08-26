namespace Authentication.Services
{
    using User.Data.Models;
    public interface IJWTAuthenticationManager
    {
        Authentication Authenticate(string username, string password);
    }
}
