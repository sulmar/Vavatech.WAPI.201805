using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Vavatech.WAPI.Models;

namespace Vavatech.WAPI.IServices
{
    public interface IUsersService
    {
        User Get(string login, string hashPassword);

    }
}
