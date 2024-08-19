using BlackCats_Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction.IService
{
    public interface ITokenService
    {
        string GenerateJWToken(LoginResponse loginResponse);
    }
}
