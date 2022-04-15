namespace WebApi.Controllers
{
    using System;
    using System.Linq;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;
        private IPlayerService _playerService;

        public TokenController(ITokenService tokenService, IPlayerService playerService)
        {
            _playerService = playerService;
            this.tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh(TokenApiModel tokenApiModel)
        {
            if (tokenApiModel is null)
            {
                return BadRequest("Invalid client request");
            }

            string accessToken = tokenApiModel.AccessToken;
            string refreshToken = tokenApiModel.RefreshToken;
            var principal = tokenService.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name; // this is mapped to the Name claim by default
            var user = _playerService.GetPlayers().SingleOrDefault(u => u.Username == username);
            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return BadRequest("Invalid client request");
            }

            var newAccessToken = tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = tokenService.GenerateRefreshToken();
            user.RefreshToken = newRefreshToken;
            _playerService.EditPlayer(new PlayerEditRequestDto(user));
            return new ObjectResult(new
            {
                accessToken = newAccessToken,
                refreshToken = newRefreshToken,
            });
        }

        [HttpPost]
        [Authorize]
        [Route("revoke")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var user = _playerService.GetPlayers().SingleOrDefault(u => u.Username == username);
            if (user == null)
            {
                return BadRequest();
            }

            user.RefreshToken = null;
            _playerService.EditPlayer(new PlayerEditRequestDto(user));
            return NoContent();
        }
    }
}
