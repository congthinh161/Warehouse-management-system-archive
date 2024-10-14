using WHM.Data.Dtos.Requests;
using Whm.Data.Entities;
using WHM.Data.Dtos.Responses;

namespace WHM.Application.Services.Interfaces
{
    public interface IWhmAccountService
    {
        Task<WhmAccount?> UserLogin(UserLoginRequestDto rqUser);
        Task<bool> UserRegister(UserRegisterRequestDto rqUser);
        Task<WhmAccount?> FindUserByUsername(string? username);
        Task<IEnumerable<UserInfoResponseDto>> GetAllUser();
    }
}
