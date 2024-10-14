using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WHM.Data.Dtos.Requests;
using WHM.FE.Constants;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Category
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;
        private readonly IApiCallerGeneric _apiCaller;
        public EditModel(ILogger<EditModel> logger, IApiCallerGeneric apiCaller)
        {
            _logger = logger;
            _apiCaller = apiCaller;
        }
        public string categoryId { get; set; }
        public string categoryName { get; set; }
        public string categoryDescription { get; set; }
        public void OnGet(string? CategoryId, string? CategoryName, string? CategoryDescription)
        {
            if (CategoryId!= null && CategoryName != null)
            {
                categoryId = CategoryId;
                categoryName = CategoryName;
                if (CategoryDescription != null)
                {
                    categoryDescription = CategoryDescription;
                }
            }
        }

        public void OnPost(UpdateCategoryRequest request)
        {
            var result = _apiCaller.PutData("api/Category/UpdateCategory", request, CommonConstant.API_NAME);
            Response.Redirect("/Category/CategoryList");
        }
    }
}
