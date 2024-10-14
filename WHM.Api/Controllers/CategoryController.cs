using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Whm.Data.Entities;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;
using static Whm.Infrastructure.Enums.SystemEnum;

namespace WHM.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IWhmCategoryService _categoryService;

        public CategoryController(IWhmCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]
        public async Task<IActionResult> ListCategory()
        {
            var result = await _categoryService.GetCategorys().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]
        public async Task<IActionResult> AddCategory(AddCategoryRequestDto categoryRequest)
        {
            var result = _categoryService.AddCategory(categoryRequest);
            return Ok(result);
        }
        //[HttpGet]
        //public async Task<IActionResult> GetCategoryById([FromRoute] string id)
        //{
        //    var result = _categoryService.GetCategoryById(id);
        //    return Ok(result);
        //}
        [HttpGet("{name}")]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]
        public async Task<IActionResult> SearchCategoryByName([FromRoute]string name)
        {
            var result = _categoryService.SearchCategoryByName(name).ToList();
            return Ok(result);
        }
        [HttpPut]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest whmCategory)
        {
            var result = _categoryService.UpdateCategory(whmCategory);
            return Ok(result);
        }
    }
}
