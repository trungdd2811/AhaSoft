using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Identity.Read.Service.Infrastructure;
using Identity.Common;
using Services.Common.DomainObjects.Enum;
namespace Identity.Read.Service.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public class SignInInfo
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }

        private IUsersQueries _usersQueries;
        public UsersController(IUsersQueries usersQueries)
        {
            _usersQueries = usersQueries;
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] SignInInfo signIn)
        {
            var user = _usersQueries.Authenticate(signIn.UserName, signIn.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet]
        [Authorize(Policy = nameof(Policies.NormalUsers))]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _usersQueries.GetUsersAsync();
            return Ok(users);
        }
    }
}