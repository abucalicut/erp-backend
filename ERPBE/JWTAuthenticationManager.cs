using ERPBE.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ERPBE
{
    public class JWTAuthenticationManager : IJWTAuthenticationManager
    {
        private readonly IDictionary<string, string> authUser = new Dictionary<string, string>       {
        {
            "admin","123"
        },
        {
            "anas","1234"
        }
    };
        public readonly string key;
        public JWTAuthenticationManager(string key)
        {
            this.key = key;
        }
        public Authentication Authenticate(string username, string password)
        {
            if (!authUser.Any(x => x.Key == username && x.Value == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            Authentication objAuth = new Authentication();
            objAuth.token= tokenHandler.WriteToken(token);
            objAuth.UserName = username;
            objAuth.validTo = token.ValidTo;
            return objAuth;
        }
    }
}
