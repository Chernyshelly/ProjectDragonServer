namespace WebApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.IdentityModel.Tokens;

    [ApiController]
    [Route("api/Auth")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> logger;

        public AuthController(ILogger<AuthController> logger)
        {
            this.logger = logger;
        }

        [HttpPost("login")]
        public async Task LoginAsync(HttpContext context)
        {
            var claimsIdentity = new ClaimsIdentity("Bearer");
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // установка аутентификационных куки
            await context.SignInAsync(claimsPrincipal);
        }

        [HttpGet("token/{username}")]
        public string GetToken(string username)
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };

            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    claims: claims,
                    expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        [HttpGet("test")]
        public string Test(HttpContext context)
        {
            var user = context.User.Identity;
            if (user is not null && user.IsAuthenticated)
            {
                return $"Пользователь аутентифицирован. Тип аутентификации: {user.AuthenticationType}";
            }
            else
            {
                return "Пользователь НЕ аутентифицирован";
            }
        }
    }
}
