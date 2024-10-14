using Whm.Data.Entities;
using WHM.Data.Dtos.Requests;
using WHM.Application.Services.Interfaces;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Whm.Data.EF;

namespace WHM.Application.Services
{
    public class WhmProductOutputService : IWhmProductOutputService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WhmProductOutputService> _logger;
        private readonly IMapper _mapper;
        public WhmProductOutputService(IUnitOfWork unitOfWork, ILogger<WhmProductOutputService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public bool OutputProduct(List<WhmOutputProduct> whmOutputProducts, WhmProductOuput whmProductOuput)
        {
            try
            {
                //Add ProductOutput
                _unitOfWork.WhmProductOutputRepository.AddProductOutput(whmProductOuput);
                _unitOfWork.Commit();
                //Add ProductOutputDetails
                var productOutputDetails = whmOutputProducts.Select(p => new WhmProductOutputDetail()
                {
                    ProdOutputId = whmProductOuput.ProdOuputId,
                    ProductId = p.ProductId,
                    Quantity = p.Quanity,
                    OutputPrice = p.EstimatedPrice
                }).ToList();
                _unitOfWork.WhmProductOutputDetailsRepository.AddOutputProductDetails(productOutputDetails);
                _unitOfWork.Commit();
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
