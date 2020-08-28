using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.auth.API.Model
{
    public class UserDTO
    {
        public string Nome { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
