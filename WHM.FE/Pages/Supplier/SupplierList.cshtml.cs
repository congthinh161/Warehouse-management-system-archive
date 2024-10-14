using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whm.Data.Entities;
using WHM.Data.Dtos.Responses;
using WHM.FE.Constants;
using WHM.FE.Pages.Category;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Supplier
{
    public class SupplierListModel : PageModel
    {
        private readonly ILogger<SupplierListModel> _logger;
        private readonly IApiCallerGeneric _apiCaller;
        public SupplierListModel(ILogger<SupplierListModel> logger, IApiCallerGeneric apiCaller)
        {
            _logger = logger;
            _apiCaller = apiCaller;
        }
        public List<WhmSuplier>? suppliers { get; set; } = new List<WhmSuplier>();
        public void OnGet()
        {
            suppliers = _apiCaller.GetApiData<List<WhmSuplier>>("api/Supplier/ListSupplier", CommonConstant.API_NAME).Result;
        }
    }
}
