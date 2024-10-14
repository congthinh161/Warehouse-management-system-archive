using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Whm.Data.EF;
using Whm.Data.Entities;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;

namespace WHM.Application.Services
{
    public class WhmSupplierService : IWhmSupplierService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WhmSupplierService> _logger;
        private readonly IMapper _mapper;
        public WhmSupplierService(IUnitOfWork unitOfWork, ILogger<WhmSupplierService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<SupplierResponseDto>> GetSupliers()
        {
            try
            { 
            var result = await _unitOfWork.WhmSupplierRepository.GetSupliers().ToListAsync().ConfigureAwait(false);
            return _mapper.Map<List<SupplierResponseDto>>(result);
            }catch (Exception ex)
            {
                return null;
            }
        }

        public bool AddSuplier(AddSupplierRequestDto addSupplier)
        {
            WhmSuplier whmSuplier = _mapper.Map<WhmSuplier>(addSupplier);
            try
            {
                if (whmSuplier.SuplierId == Guid.Empty)
                {
                    _unitOfWork.WhmSupplierRepository.AddSupplier(whmSuplier);
                    _unitOfWork.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool UpdateSupplier(UpdateSupplierRequest whmSuplier)
        {
            try
            {
                if (whmSuplier.SuplierId != Guid.Empty)
                {
                    var suplier = _unitOfWork.WhmSupplierRepository.GetSupplierById(whmSuplier.SuplierId);
                    suplier.Address = whmSuplier.Address;
                    suplier.Phone = whmSuplier.Phone;
                    suplier.Email = whmSuplier.Email;
                    suplier.DisplayName = whmSuplier.DisplayName;
                    suplier.MoreInfo = whmSuplier.MoreInfo;
                    _unitOfWork.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SupplierResponseDto> SearchSupplier(string displayName)
        {
            var resutl = _unitOfWork.WhmSupplierRepository.SearchSupplier(displayName).ToList();
            return _mapper.Map<List<SupplierResponseDto>>(resutl);
        }

    }
}
