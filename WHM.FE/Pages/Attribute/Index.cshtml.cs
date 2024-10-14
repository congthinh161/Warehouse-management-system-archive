using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WHM.Data.Dtos.Responses;
using WHM.FE.Constants;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Attribute
{
    public class IndexModel : PageModel
    {
        private readonly IApiCallerGeneric _apiCaller;

        public IndexModel(IApiCallerGeneric apiCaller)
        {
            _apiCaller = apiCaller;
        }

        public async Task<IActionResult> OnGet()
        {
            var data = await _apiCaller.GetApiData<List<AttributeResponseDto>>("api/Attribute/GetAll", CommonConstant.API_NAME);

            ViewData["attributes"] = data;
            return Page();
        }
    }
}
