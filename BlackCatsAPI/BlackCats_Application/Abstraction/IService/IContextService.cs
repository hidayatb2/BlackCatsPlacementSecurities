using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Application.Abstraction.IService
{
    public interface IContextService
    {
        string GetUserId();

        string GetUserName();

        string GetUserRole();
    }
}
