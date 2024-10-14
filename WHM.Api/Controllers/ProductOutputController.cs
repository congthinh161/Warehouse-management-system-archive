using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WHM.Application.Services;
using WHM.Application.Services.Interfaces;
using static Whm.Infrastructure.Enums.SystemEnum;

namespace WHM.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductOutputController : ControllerBase
    {
        private readonly IWhmProductOutputService _whmProductOutputService;

        public ProductOutputController(IWhmProductOutputService whmProductOutputService)
        {
            _whmProductOutputService = whmProductOutputService;
        }

        //[HttpPost]
        //public async Task<IActionResult> AddProductOutput(Guid supplierId, float preMoney, string description)
        //{
        //    var result = _whmProductOutputService.OutputProduct(supplierId, preMoney, description);
        //    if (result)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
