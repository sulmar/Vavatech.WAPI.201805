using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WAPI.IServices;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.MockServices
{
    public class MockUsersService : IUsersService
    {
        private static IList<User> users = new List<User>
        {
            new User(1, "marcin", "12345" ),
            new User(2, "bartek", "12345" ),
            new User(3, "kasia", "12345" ),
        };

        public User Get(string login, string securePassword)
        {
            return users.SingleOrDefault(u => u.Login == login && u.IsValid(securePassword));
        }
    }
}
