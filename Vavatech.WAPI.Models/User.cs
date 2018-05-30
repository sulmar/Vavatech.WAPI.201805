using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.WAPI.Models
{
    public class User : Base
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public SecureString Password { get; private set; }

        public string Email { get; set; }

        public User(int id, string login, string password)
        {
            this.Id = id;
            this.Login = login;
            this.Password = new NetworkCredential(this.Login, password).SecurePassword;
        }

        public bool IsValid(string password)
        {
            return password == new NetworkCredential(this.Login, this.Password).Password;
        }
    }
}
