using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using WHM.Data.Dtos.Requests;
using WHM.FE.Constants;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Supplier
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

        public string SuplierId { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string MoreInfo { get; set; }
        public void OnGet(UpdateSupplierRequest request)
        {
            if (request != null)
            {
                SuplierId = request.SuplierId.ToString();
                DisplayName = request.DisplayName;
                Address = request.Address;
                Phone = request.Phone;
                Email = request.Email;
                MoreInfo = request.MoreInfo;
            }
        }
        public void OnPost(UpdateSupplierRequest request)
        {
            var result = _apiCaller.PutData("api/Supplier/UpdateSupplier", request, CommonConstant.API_NAME);
            Response.Redirect("/Supplier/SupplierList");
        }
    }
}
