using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.auth.API.Model
{
    public class JsonWebToken
    {
        public string AccessToken { get; set; }
       
        public string TokenType { get; set; } = "bearer";
        public long ExpiresIn { get; set; }
    }
}
