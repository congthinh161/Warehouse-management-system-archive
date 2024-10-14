using AutoMapper;
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

namespace WHM.Application.Services
{
    public class WhmCategoryAttributeService : IWhmCategoryAttributeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WhmCategoryAttributeService> _logger;
        private readonly IMapper _mapper;
        public WhmCategoryAttributeService(IUnitOfWork unitOfWork, ILogger<WhmCategoryAttributeService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public bool AddCategoryAttribute(AddCategoryAttributeRequestDto requestDto)
        {
            WhmCategoryAttribute whmCategoryAttribute = _mapper.Map<WhmCategoryAttribute>(requestDto);
            try
            {
                _unitOfWork.WhmCategoryRepository.AddCategoryAttribute(whmCategoryAttribute);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
