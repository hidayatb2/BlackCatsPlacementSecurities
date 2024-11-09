using BlackCats_Application.Abstraction.IService;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackCats_Infrastructure.Identity
{
    public class ContextService : IContextService
    {
        private readonly IHttpContextAccessor contextAccessor;

        public ContextService(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }
        public string GetUserId()
        {
           var id = contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x?.Type == "Id")?.Value;
            if (id == null)
                return string.Empty;
            return id;
        }

        public string GetUserName()
        {
            throw new NotImplementedException();
        }

        public  string GetUserRole()
        {
            var UserRole = contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x?.Type == "Roles")?.Value;
            if (UserRole is null)
                return string.Empty;
            return UserRole;
        }
    }
}
