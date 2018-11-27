using System;
using System.Collections.Generic;
using Services.Common.DomainObjects;
namespace Identity.Common
{
    public class UserDto : ReadObject
    {
        public UserDto()
        {
            Id = 0;
            UserRoles = new List<string>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
        public string AuthToken { get; set; }
    }
}
