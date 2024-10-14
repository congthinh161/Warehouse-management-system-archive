using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whm.Data.Entities;
using WHM.Data.Dtos.Responses;
using WHM.FE.Constants;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.User
{
    public class UserlistModel : PageModel
    {
        private readonly IApiCallerGeneric _apiCaller;

        public UserlistModel(IApiCallerGeneric apiCaller)
        {
            _apiCaller = apiCaller;
        }

        public async Task<IActionResult> OnGet()
        {
            var data = await _apiCaller.GetApiData<List<UserInfoResponseDto>>("api/User/GetAllUser", CommonConstant.API_NAME);

            ViewData["Users"] = data;
            return Page();
        }
    }
}
