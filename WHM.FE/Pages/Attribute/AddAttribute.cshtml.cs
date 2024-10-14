using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WHM.Data.Dtos.Requests;
using WHM.FE.Constants;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Attribute
{
    public class AddAttributeModel : PageModel
    {
        private readonly IApiCallerGeneric _apiCaller;

        public AddAttributeModel(IApiCallerGeneric apiCaller)
        {
            _apiCaller = apiCaller;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost([FromForm] AttributeRequestDto rqDto)
        {
            var status = await _apiCaller.PostApi<AttributeRequestDto>("api/Attribute/AddAttribute", rqDto, CommonConstant.API_NAME);

            if (status)
            {
                ViewData["message"] = "Add successfully!";
                return Page();
            }

            ViewData["message"] = "Add failed!";
            return Page();
        }
    }
}
