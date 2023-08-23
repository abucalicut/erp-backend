namespace Authentication.Services
{
    public interface IJWTAuthenticationManager
    {
        Authentication Authenticate(string username, string password);
    }
}
