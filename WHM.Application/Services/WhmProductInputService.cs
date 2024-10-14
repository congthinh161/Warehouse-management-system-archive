using AutoMapper;
using Microsoft.Extensions.Logging;
using Whm.Data.EF;
using Whm.Data.Entities;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;

namespace WHM.Application.Services
{
    public class WhmProductInputService : IWhmProductInputService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WhmProductInputService> _logger;
        private readonly IMapper _mapper;
        public WhmProductInputService(IUnitOfWork unitOfWork, ILogger<WhmProductInputService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<bool> InputProduct(AddProductInput rqDto)
        {
            try
            {
                //Add ProductInput
                var mappedInput = _mapper.Map<WhmProductInput>(rqDto);
                var mappedInputDetail = _mapper.Map<List<WhmProductInputDetail>>(rqDto.ProductInputDetails);

                await _unitOfWork.WhmProductInputRepository.AddAsync(mappedInput);
                await _unitOfWork.CommitAsync();

                if (mappedInput.ProdInputId != Guid.Empty)
                {
                    foreach (var detail in mappedInputDetail)
                    {
                        detail.ProdInputId = mappedInput.ProdInputId;
                        _unitOfWork.WhmProductInputDetailsRepository.AddProductInputDetails(detail);

                    }

                    await _unitOfWork.CommitAsync();
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
