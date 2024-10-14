using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;
using WHM.FE.Constants;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IApiCallerGeneric _apiCaller;

        public IndexModel(ILogger<IndexModel> logger, IApiCallerGeneric apiCaller)
        {
            _logger = logger;
            _apiCaller = apiCaller;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost([FromForm] UserLoginRequestDto userRq)
        {
            var data = await _apiCaller.PostApi<UserLoginRequestDto, UserLoginResponseDto>("api/User/UserLogin", userRq, CommonConstant.API_NAME);
            if (data == null)
            {
                return Page();
            }

            var handler = new JwtSecurityTokenHandler();
            var decodedValue = handler.ReadJwtToken(data.AccessToken);
            var userName = decodedValue.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Name)?.Value;
            var role = decodedValue.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

            HttpContext.Session.SetString("JWT", data.AccessToken);
            HttpContext.Session.SetString("NAME", userName);
            HttpContext.Session.SetString("ROLE", role);
            return Redirect("/Common/Dashboard");
        }

        public IActionResult OnGetLogOut()
        {
            HttpContext.Session.Clear();
            return Redirect("/");
        }
    }
}