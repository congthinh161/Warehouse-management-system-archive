using Microsoft.AspNetCore.Mvc;
using Whm.Data.Entities;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;

namespace WHM.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly IWhmSupplierService _supplierService;

        public SupplierController(IWhmSupplierService supplierService)
        {
            _supplierService = supplierService;
        }


        [HttpGet]
        public async Task<IActionResult> ListSupplier()
        {
            var result = await _supplierService.GetSupliers().ConfigureAwait(false);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddSupplier(AddSupplierRequestDto addSupplier)
        {
            var result = _supplierService.AddSuplier(addSupplier);
            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> SearchSupplierByName([FromRoute] string name)
        {
            var result = _supplierService.SearchSupplier(name).ToList();
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSupplier(UpdateSupplierRequest whmSupplier)
        {
            var result = _supplierService.UpdateSupplier(whmSupplier);
            return Ok(result);
        }
    }
}
