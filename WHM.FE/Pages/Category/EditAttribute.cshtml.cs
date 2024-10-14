using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;
using WHM.FE.Constants;
using WHM.FE.Services.Interfaces;

namespace WHM.FE.Pages.Category
{
    public class EditAttributeModel : PageModel
    {
        private readonly ILogger<EditAttributeModel> _logger;
        private readonly IApiCallerGeneric _apiCaller;
        public EditAttributeModel(ILogger<EditAttributeModel> logger, IApiCallerGeneric apiCaller)
        {
            _logger = logger;
            _apiCaller = apiCaller;
        }
        public List<CategoryResponseDto>? categoryResponseDtos { get; set; } = new List<CategoryResponseDto>();
        public List<AttributeResponseDto>? attributeResponseDtos { get; set; } = new List<AttributeResponseDto>();
        public void OnGet()
        {
            categoryResponseDtos =  _apiCaller.GetApiData<List<CategoryResponseDto>>("api/Category/ListCategory", CommonConstant.API_NAME).Result;
            attributeResponseDtos = _apiCaller.GetApiData<List<AttributeResponseDto>>("api/Attribute/GetAll", CommonConstant.API_NAME).Result;
        }
        public IActionResult OnPost(AddCategoryAttributeRequestDto requestDto)
        {
            var result = _apiCaller.PostApi("api/CategoryAttribute/AddCategoryAttribute", requestDto, CommonConstant.API_NAME).Result;
            categoryResponseDtos = _apiCaller.GetApiData<List<CategoryResponseDto>>("api/Category/ListCategory", CommonConstant.API_NAME).Result;
            attributeResponseDtos = _apiCaller.GetApiData<List<AttributeResponseDto>>("api/Attribute/GetAll", CommonConstant.API_NAME).Result;
            if (result)
            {
                ViewData["Mess"] = "Add Success";
            }
            else
            {
                ViewData["Mess"] = "Fail!!! Category Attribute Is Exist.";
            }
            return Page();
            //Response.Redirect("/Category/EditAttribute");
        }
    }
}
