using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Whm.Data.Entities;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;
using static Whm.Infrastructure.Enums.SystemEnum;

namespace WHM.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductInputController : ControllerBase
    {
        private readonly IWhmProductInputService _whmProductInputService;

        public ProductInputController(IWhmProductInputService whmProductInputService)
        {
            _whmProductInputService = whmProductInputService;
        }

        [HttpPost]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]
        public async Task<IActionResult> AddProductInput([FromBody]AddProductInput rqDto)
        {
            var result = await _whmProductInputService.InputProduct(rqDto);
            if (result)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]
        public async Task<IActionResult> AddProductInputDetail()
        {
            return Ok();
        }
    }
}
