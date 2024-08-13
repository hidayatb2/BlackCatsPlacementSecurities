using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BlackCatsAPI.Controllers.Common
{
    public class ApiController : ControllerBase
    {
        protected internal string RequestedUrl=>Request.GetEncodedUrl();

        protected CreatedResult Created<T>(T obj)
        {
            return Created(obj);
        }
    }
}
