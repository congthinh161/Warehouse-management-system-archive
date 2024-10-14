using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;
using static Whm.Infrastructure.Enums.SystemEnum;

namespace WHM.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttributeController : ControllerBase
    {
        private readonly IWhmAttributeService _whmAttributeService;

        public AttributeController(IWhmAttributeService whmAttributeService)
        {
            _whmAttributeService = whmAttributeService;
        }

        [HttpGet]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]

        public async Task<IActionResult> GetAll()
        {
            var attributes = await _whmAttributeService.GetAllAttributes();
            return Ok(attributes);
        }

        [HttpPost]
        [Authorize(Roles = $"{nameof(UserRoles.Owner)},{nameof(UserRoles.Manager)}")]
        public async Task<IActionResult> AddAttribute([FromBody]AttributeRequestDto rqDto)
        {
            bool isSuccess = await _whmAttributeService.AddAttribute(rqDto)
                .ConfigureAwait(false);

            if (!isSuccess)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
