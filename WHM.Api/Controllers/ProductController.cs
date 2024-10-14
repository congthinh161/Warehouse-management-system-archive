using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;
using static Whm.Infrastructure.Enums.SystemEnum;

namespace WHM.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IWhmProductService _whmProductService;

        public ProductController(IWhmProductService whmProductService)
        {
            _whmProductService = whmProductService;
        }

        [HttpGet]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]
        public async Task<IActionResult> GetAllProducts()
        {
            var data = await _whmProductService.GetAllProducts();
            return Ok(data);
        }

        [HttpPost]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]
        public async Task<IActionResult> AddNewProduct([FromBody] ProductRequestDto rqDto)
        {
            var status = await _whmProductService.AddNewProduct(rqDto);

            if (!status)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]
        public async Task<IActionResult> GetProductAttribute([FromRoute] Guid id)
        {
            var data = await _whmProductService.GetProductAttributes(id);
            if (data is null)
            {
                return BadRequest();
            }
            return Ok(data);
        }

        [HttpPost]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]
        public async Task<IActionResult> AddProductAttributeValue([FromBody] AddProductAttributeRequestDto rqDto)
        {
            var status = await _whmProductService.AddProductAttributeValue(rqDto);
            if(!status)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
