using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;
using static Whm.Infrastructure.Enums.SystemEnum;

namespace WHM.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryAttributeController : ControllerBase
    {
        private readonly IWhmCategoryAttributeService _categoryAttributeService;

        public CategoryAttributeController(IWhmCategoryAttributeService categoryAttributeService)
        {
            _categoryAttributeService = categoryAttributeService;
        }

        [HttpPost]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]
        public async Task<IActionResult> AddCategoryAttribute(AddCategoryAttributeRequestDto requestDto)
        {
            var result = _categoryAttributeService.AddCategoryAttribute(requestDto);
            if (result)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
