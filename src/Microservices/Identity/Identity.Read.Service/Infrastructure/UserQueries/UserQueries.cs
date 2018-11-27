using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Identity.Common;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Identity.Read.Service.Infrastructure.Configuration;
using Services.Common.DomainObjects.Enum;
namespace Identity.Read.Service.Infrastructure
{
    public class UsersQueries : IUsersQueries
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<UserDto> _users = new List<UserDto>
        {
            new UserDto {
                Id = 1,
                FirstName = "Aha",
                LastName = "User",
                UserName = "aha_user",
                Password = "test",
                UserRoles = new List<string>(){nameof(Roles.Staff)}
            },
             new UserDto {
                Id = 1,
                FirstName = "Aha",
                LastName = "Manager",
                UserName = "aha_manager",
                Password = "test",
                UserRoles = new List<string>(){ nameof(Roles.Staff), nameof(Roles.Manager) }
            }
        };

        private readonly IdentitySettings _appSettings;
        public UsersQueries(IOptions<IdentitySettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public UserDto Authenticate(string userName, string password)
        {
            var user = _users.SingleOrDefault(u => u.UserName == userName && u.Password == password);
            if (user == null) return null;
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName.ToString()));
            foreach (string role in user.UserRoles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.AuthToken = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;
            return user;

        }

        public Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            // return users without passwords
            var result =  _users.Select(x => {
                x.Password = null;
                return x;
            });
            return Task.FromResult<IEnumerable<UserDto>>(result);
        }
    }
}
