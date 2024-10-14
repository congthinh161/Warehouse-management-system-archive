using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whm.Infrastructure.Helpers;
using WHM.Data.Dtos.Requests;
using WHM.FE.Constants;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.User
{
    public class RegisterModel : PageModel
    {
        private readonly IApiCallerGeneric _apiCaller;

        public RegisterModel(IApiCallerGeneric apiCaller)
        {
            _apiCaller = apiCaller;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost([FromForm] UserRegisterRequestDto rqDto)
        {
            rqDto.Password = StringHelper.GenerateStringMode3(8);

            var status = await _apiCaller.PostApi<UserRegisterRequestDto>("api/User/UserRegister", rqDto, CommonConstant.API_NAME);

            if (status)
            {
                ViewData["pass"] = rqDto.Password;
                ViewData["message"] = "Register successfully!";
                return Page();
            }

            ViewData["message"] = "Register failed!";
            return Page();
        }
    }
}
