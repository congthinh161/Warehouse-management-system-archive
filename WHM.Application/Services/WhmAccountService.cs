using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Whm.Data.EF;
using Whm.Data.Entities;
using Whm.Infrastructure.Enums;
using Whm.Infrastructure.Helpers;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;

namespace WHM.Application.Services
{
    public class WhmAccountService : IWhmAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WhmAccountService> _logger;
        private readonly IMapper _mapper;

        public WhmAccountService(IUnitOfWork unitOfWork, ILogger<WhmAccountService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<WhmAccount?> UserLogin(UserLoginRequestDto rqUser)
        {
            try
            {
                var user = await _unitOfWork.WhmAccountRepository
                    .FindObject(x => x.UserName.Equals(rqUser.UserName)
                                && !x.IsDelete)
                    .ConfigureAwait(false);

                if (user is not null && HashingHelper.VerifyPassword(rqUser.Password, user.Password))
                {
                    return user;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public async Task<bool> UserRegister(UserRegisterRequestDto rqUser)
        {
            try
            {
                var userEntity = _mapper.Map<WhmAccount>(rqUser);
                userEntity.Password = HashingHelper.EncryptPassword(rqUser.Password);
                userEntity.RoleId = rqUser.RoleId;

                await _unitOfWork.WhmAccountRepository
                    .AddAsync(userEntity)
                    .ConfigureAwait(false);

                await _unitOfWork.CommitAsync()
                    .ConfigureAwait(false);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return false;
        }

        public async Task<WhmAccount?> FindUserByUsername(string? username)
        {
            try
            {
                var user = await _unitOfWork.WhmAccountRepository
                    .FindObject(x => x.UserName.Equals(username)
                                && !x.IsDelete)
                    .ConfigureAwait(false);

                return user;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return null;
        }

        public async Task<IEnumerable<UserInfoResponseDto>> GetAllUser()
        {
            try
            {
                var users = await _unitOfWork.WhmAccountRepository
                    .All().ConfigureAwait(false);
                var mappedData = _mapper.Map<IEnumerable<UserInfoResponseDto>>(users);
                return mappedData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return Enumerable.Empty<UserInfoResponseDto>();
        }
    }
}
