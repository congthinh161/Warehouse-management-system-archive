using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Whm.Data.EF;
using Whm.Data.Entities;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;

namespace WHM.Application.Services
{
    public class WhmProductService : IWhmProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<WhmProductService> _logger;

        public WhmProductService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<WhmProductService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<ProductResponseDto>> GetAllProducts()
        {
            try
            {
                var data = await _unitOfWork.WhmProductRepository
                .GetProductWithCate()
                .ToListAsync();

                var mappedData = _mapper.Map<List<ProductResponseDto>>(data);

                return mappedData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return new List<ProductResponseDto>();
        }

        public async Task<bool> AddNewProduct(ProductRequestDto rqDto)
        {
            try
            {
                var mappedData = _mapper.Map<WhmProduct>(rqDto);

                await _unitOfWork.WhmProductRepository.AddAsync(mappedData);
                await _unitOfWork.CommitAsync();
                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }

        public async Task<ProductAttributeResponseDto> GetProductAttributes(Guid productId)
        {
            try
            {
                var data = await _unitOfWork.WhmProductRepository
                    .GetProductAttribute(productId)
                    .FirstOrDefaultAsync();

                var mappedData = _mapper.Map<ProductAttributeResponseDto>(data);
                return mappedData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return null;
        }

        public async Task<bool> AddProductAttributeValue(AddProductAttributeRequestDto rqDto)
        {
            try
            {
                var mappedAttributes = _mapper.Map<List<WhmAttributeValue>>(rqDto.Attributes);

                foreach (var attributes in mappedAttributes)
                {
                    await _unitOfWork.WhmAttributeValue.AddAsync(attributes);
                }

                await _unitOfWork.CommitAsync();

                foreach (var attributes in mappedAttributes)
                {
                    var entities = new WhmProductAttributeValue(rqDto.ProductId, attributes.AttributeValueId);
                    await _unitOfWork.WhmProductAttributeValue.AddAsync(entities);
                }
                await _unitOfWork.CommitAsync();

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return false;
        }
    }
}
