using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;

namespace WHM.Application.Services.Interfaces
{
    public interface IWhmProductService
    {
        Task<List<ProductResponseDto>> GetAllProducts();
        Task<bool> AddNewProduct(ProductRequestDto rqDto);
        Task<ProductAttributeResponseDto> GetProductAttributes(Guid productId);
        Task<bool> AddProductAttributeValue(AddProductAttributeRequestDto rqDto);
    }
}
