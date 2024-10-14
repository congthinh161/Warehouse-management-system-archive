using Whm.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Security.Claims;

namespace Whm.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected string CurrentUser
        {
            get
            {
                var currentUser = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
                return currentUser == null ? "Unauthorized" : currentUser.ToString();
            }
        }

        protected string JWTToken
        {
            get
            {
                string bearer = HttpContext.Request.Headers["Authorization"];
                string token = bearer.Replace("Bearer", "");
                return token;
            }
        }

        public override OkObjectResult Ok([ActionResultObjectValue] object? value)
        {
            return base.Ok(new ApiFormatResponse(200, new Response(true, value)));
        }

        public override UnauthorizedObjectResult Unauthorized([ActionResultObjectValue] object? value)
        {
            return base.Unauthorized(new ApiFormatResponse(401, new Response(false, value)));
        }

        public override NotFoundObjectResult NotFound([ActionResultObjectValue] object? value)
        {
            return base.NotFound(new ApiFormatResponse(404, new Response(false, value)));
        }

        public override BadRequestObjectResult BadRequest([ActionResultObjectValue] object? error)
        {
            return base.BadRequest(new ApiFormatResponse(400, new Response(false, error)));
        }
    }
}
