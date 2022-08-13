using BusinessLayer.Abstract;
using BusinessLayer.Configuration.Auth;
using BusinessLayer.Configuration.CommandResponse;
using DataAccessLayer.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public AccessToken Login(string nationalityId, string password)
        {
            var verifyPassword = VerifyPassword(nationalityId, password);
            var user = _userRepository.Get(x => x.NationalityId == nationalityId);

            if (verifyPassword.Status)
            {
                var tokenOption = _configuration.GetSection("TokenOptions").Get<TokenOption>();

                var expireDate = DateTime.Now.AddDays(tokenOption.AccessTokenExpiration);

                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.NationalityId),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                };

                SecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOption.SecurityKey));
                var jwtToken = new JwtSecurityToken(
                    issuer: tokenOption.Issuer,
                    audience: tokenOption.Audience,
                    claims: claims,
                    expires: expireDate,
                    signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
                    );
                var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

                return new AccessToken()
                {
                    Token = token,
                    ExpireDate = expireDate
                };

            }

            return new AccessToken()
            {

            };
            
        }

        public CommandResponse VerifyPassword(string nationalityId, string password)
        {
            var user = _userRepository.GetUserWithPassword(nationalityId);

            if (HashHelper.VerifyPasswordHash(password, user.Password.PasswordHash, user.Password.PasswordSalt))
            {
                return new CommandResponse()
                {
                    Status = true,
                    Message = "Giriş Başarılı"
                };
            }

            return new CommandResponse()
            {
                Status = false,
                Message = "Giriş Başarısız"
            };
        }
    }
}
