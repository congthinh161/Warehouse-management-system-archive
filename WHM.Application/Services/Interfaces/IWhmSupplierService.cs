using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whm.Data.Entities;
using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;

namespace WHM.Application.Services.Interfaces
{
    public interface IWhmSupplierService
    {
        public Task<List<SupplierResponseDto>> GetSupliers();
        public bool AddSuplier(AddSupplierRequestDto addSupplier);
        public bool UpdateSupplier(UpdateSupplierRequest whmSuplier);
        public List<SupplierResponseDto> SearchSupplier(string displayName);
    }
}
