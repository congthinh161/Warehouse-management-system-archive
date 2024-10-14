using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WHM.Data.Dtos.Requests;
using Whm.Data.Entities;
using WHM.FE.Constants;
using WHM.FE.Pages.Category;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Supplier
{
    public class AddSupplierModel : PageModel
    {
        private readonly ILogger<AddSupplierModel> _logger;
        private readonly IApiCallerGeneric _apiCaller;
        public AddSupplierModel(ILogger<AddSupplierModel> logger, IApiCallerGeneric apiCaller)
        {
            _logger = logger;
            _apiCaller = apiCaller;
        }

        public IActionResult OnPost(AddSupplierRequestDto requestDto)
        {
            var result = _apiCaller.PostApi<AddSupplierRequestDto>("api/Supplier/AddSupplier", requestDto, CommonConstant.API_NAME).Result;
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
