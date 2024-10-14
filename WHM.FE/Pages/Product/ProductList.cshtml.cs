using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WHM.Data.Dtos.Responses;
using WHM.FE.Constants;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Product
{
    public class ProductListModel : PageModel
    {
        private readonly IApiCallerGeneric _apiCaller;

        public ProductListModel(IApiCallerGeneric apiCaller)
        {
            _apiCaller = apiCaller;
        }
        
        public async Task<IActionResult> OnGet()
        {
            var data = await _apiCaller.GetApiData<List<ProductResponseDto>>("api/Product/GetAllProducts", CommonConstant.API_NAME);

            ViewData["products"] = data;
            return Page();
        }
    }
}
