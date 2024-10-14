using WHM.Data.Dtos.Requests;

namespace WHM.Application.Services.Interfaces
{
    public interface IWhmProductInputService
    {
        public Task<bool> InputProduct(AddProductInput rqDto);
    }
}
