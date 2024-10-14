
using AutoMapper;
using Microsoft.Extensions.Logging;
using Whm.Data.EF;
using Whm.Data.Entities;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;

namespace WHM.Application.Services
{
    public class WhmAttributeService : IWhmAttributeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<WhmAttributeService> _logger;

        public WhmAttributeService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<WhmAttributeService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IEnumerable<AttributeResponseDto>> GetAllAttributes()
        {
            try
            {
                var data = await _unitOfWork.WhmAttributeRepository
                    .All()
                    .ConfigureAwait(false);

                var mappedData = _mapper.Map<IEnumerable<AttributeResponseDto>>(data);

                return mappedData;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Enumerable.Empty<AttributeResponseDto>();
        }

        public async Task<bool> AddAttribute(AttributeRequestDto rqDto)
        {
            try
            {
                var attribute = _mapper.Map<WhmAttribute>(rqDto);

                await _unitOfWork.WhmAttributeRepository
                    .AddAsync(attribute)
                    .ConfigureAwait(false);

                await _unitOfWork.CommitAsync()
                    .ConfigureAwait(false);
                return true;
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }
    }
}
