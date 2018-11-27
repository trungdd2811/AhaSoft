using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.Common;
namespace Identity.Read.Service.Infrastructure
{
    public interface IUsersQueries
    {
        UserDto Authenticate(string userName, string password);
        Task<IEnumerable<UserDto>> GetUsersAsync();
    }
}
