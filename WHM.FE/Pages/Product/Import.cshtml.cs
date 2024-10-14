using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Whm.Data.Entities;
using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;
using WHM.FE.Constants;
using WHM.FE.Pages.Category;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Product
{
    [IgnoreAntiforgeryToken]
    public class ImportModel : PageModel
    {
        private readonly ILogger<ImportModel> _logger;
        private readonly IApiCallerGeneric _apiCaller;
        public ImportModel(ILogger<ImportModel> logger, IApiCallerGeneric apiCaller)
        {
            _logger = logger;
            _apiCaller = apiCaller;
        }
        public List<ProductResponseDto> products { get; set; } = new List<ProductResponseDto>();
        public List<WhmSuplier> suppliers { get; set; } = new List<WhmSuplier>();
        public void OnGet()
        {
            products = _apiCaller.GetApiData<List<ProductResponseDto>>("api/Product/GetAllProducts", CommonConstant.API_NAME).Result;
            suppliers = _apiCaller.GetApiData<List<WhmSuplier>>("api/Supplier/ListSupplier", CommonConstant.API_NAME).Result;
        }
        public IActionResult OnPost([FromForm]List<AddProductInputDetailsDto> ProductInputDetails, [FromForm] string SuplierId, [FromForm] string PreMoney, [FromForm] string Description)
        {
            AddProductInput addProductInput = new AddProductInput
            {
                SuplierId = Guid.Parse(SuplierId),
                PreMoney = float.Parse(PreMoney),
                Description = Description,
                ProductInputDetails = ProductInputDetails
            };
            

            var result = _apiCaller.PostApi("api/ProductInput/AddProductInput", addProductInput, CommonConstant.API_NAME).Result;
            if (result)
            {
                ViewData["Mess"] = "Add Success";
            }
            else
            {
                ViewData["Mess"] = "Fail!!!";
            }
            products = _apiCaller.GetApiData<List<ProductResponseDto>>("api/Product/GetAllProducts", CommonConstant.API_NAME).Result;
            suppliers = _apiCaller.GetApiData<List<WhmSuplier>>("api/Supplier/ListSupplier", CommonConstant.API_NAME).Result;

            return Redirect("/Product/ProductList");
        }
    }
}
