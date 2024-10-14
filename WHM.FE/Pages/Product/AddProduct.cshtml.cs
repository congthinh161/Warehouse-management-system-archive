using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WHM.Data.Dtos.Requests;
using Whm.Data.Entities;
using WHM.FE.Constants;
using WHM.FE.Pages.Supplier;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Product
{
    public class AddProductModel : PageModel
    {
        private readonly ILogger<AddProductModel> _logger;
        private readonly IApiCallerGeneric _apiCaller;
        public AddProductModel(ILogger<AddProductModel> logger, IApiCallerGeneric apiCaller)
        {
            _logger = logger;
            _apiCaller = apiCaller;
        }
        public IActionResult OnPost(ProductRequestDto requestDto)
        {
            var result = _apiCaller.PostApi<ProductRequestDto>("api/Product/AddNewProduct", requestDto, CommonConstant.API_NAME).Result;
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
