using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WHM.Data.Dtos.Responses;
using WHM.FE.Constants;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Common
{
    public class DashboardModel : PageModel
    {
        private readonly ILogger<DashboardModel> _logger;
        private readonly IApiCallerGeneric _apiCaller;
        public DashboardModel(ILogger<DashboardModel> logger, IApiCallerGeneric apiCaller)
        {
            _logger = logger;
            _apiCaller = apiCaller;
        }
        public int countPro { get; set; }
        public int countsup { get; set; }
        public  void OnGet()
        {
                 countPro =  _apiCaller.GetApiData<List<ProductResponseDto>>("api/Product/GetAllProducts", CommonConstant.API_NAME).Result.Count;
            //var countBill = _apiCaller.GetApiData("api/", CommonConstant.API_NAME);
                  countsup = _apiCaller.GetApiData<List<SupplierResponseDto>>("api/Supplier/ListSupplier", CommonConstant.API_NAME).Result.Count;
            //var countSold = _apiCaller.GetApiData("api/", CommonConstant.API_NAME);
        }
    }
}
