using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whm.Data.Entities;
using WHM.Data.Dtos.Requests;
using WHM.FE.Constants;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Category
{
    public class AddCategoryModel : PageModel
    {
        private readonly ILogger<AddCategoryModel> _logger;
        private readonly IApiCallerGeneric _apiCaller;
        public AddCategoryModel(ILogger<AddCategoryModel> logger, IApiCallerGeneric apiCaller)
        {
            _logger = logger;
            _apiCaller = apiCaller;
        }

        public IActionResult OnPost(AddCategoryRequestDto requestDto)
        {
            var result = _apiCaller.PostApi<AddCategoryRequestDto>("api/Category/AddCategory", requestDto, CommonConstant.API_NAME).Result;
            if (result)
            {
                ViewData["Mess"] = "Add Success";
            }
            else
            {
                ViewData["Mess"] = "Fail!!!";
            }
            return Page();
        }
    }
}
