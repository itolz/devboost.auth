using devboost.auth.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devboost.auth.API.Contract
{
    public interface ITokenService
    {
        JsonWebToken CreateJWT(User user);
    }
}
