using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace devboost.auth.API.Model
{
    public class User
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string Username { get; set; }
        public string PasswordHash { get; set; }

        public string Email { get; set; }
    }
}
