using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;

namespace WHM.Application.Services.Interfaces
{
    public interface IWhmAttributeService
    {
        Task<IEnumerable<AttributeResponseDto>> GetAllAttributes();
        Task<bool> AddAttribute(AttributeRequestDto rqDto);
    }
}
