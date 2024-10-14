using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whm.Data.Entities;
using WHM.Data.Dtos.Responses;
using WHM.FE.Constants;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Category
{
    public class CategoryListModel : PageModel
    {
        private readonly ILogger<CategoryListModel> _logger;
        private readonly IApiCallerGeneric _apiCaller;
        public CategoryListModel(ILogger<CategoryListModel> logger, IApiCallerGeneric apiCaller)
        {
            _logger = logger;
            _apiCaller = apiCaller;
        }
        public List<CategoryResponseDto>? categories { get; set; } = new List<CategoryResponseDto>();
        public void OnGet()
        {
            categories = _apiCaller.GetApiData<List<CategoryResponseDto>>("api/Category/ListCategory", CommonConstant.API_NAME).Result;
        }
    }
}
