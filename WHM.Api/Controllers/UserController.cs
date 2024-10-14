using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using System.Collections.ObjectModel;
using System.Security.Claims;
using WHM.Application.Services.Interfaces;
using WHM.Data.Dtos.Requests;
using WHM.Data.Dtos.Responses;
using static Whm.Infrastructure.Enums.SystemEnum;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WHM.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IWhmAccountService _accountService;
        private readonly ITokenService _tokenService;

        public UserController(IWhmAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> UserLogin([FromBody] UserLoginRequestDto userRq)
        {
            var userAccount = await _accountService.UserLogin(userRq)
                .ConfigureAwait(false);

            if (userAccount is null)
            {
                return Unauthorized("Wrong username or password!");
            }

            var userRole = (UserRoles)userAccount.RoleId;
            var authClaims = new Collection<Claim>
            {
                    new Claim(JwtRegisteredClaimNames.Name, userRq.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Role, userRole.ToString())
            };

            var accessToken = _tokenService.GenerateAccessToken(authClaims);
            return Ok(new UserLoginResponseDto(accessToken));
        }

        [HttpPost]
        [Authorize(Roles = nameof(UserRoles.Owner))]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterRequestDto userRq)
        {
            var isSuccess = await _accountService.UserRegister(userRq)
                .ConfigureAwait(false);

            if (!isSuccess)
            {
                return BadRequest("Something wrong when register");
            }

            return NoContent();
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserRoles.Owner))]
        public async Task<IActionResult> GetAllUser()
        {
            var query = await _accountService.GetAllUser()
                .ConfigureAwait(false);

            return Ok(query);
        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
