namespace Application.DTO.Request
{
    using System;
    using Application.Interfaces;
    using Domain.Models;

    public class PlayerCreateRequestDto : IDtoMapper<Player>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public Player ToModel()
        {
            return new Player()
            {
                Username = this.Username,
                Password = this.Password,
                RefreshToken = this.RefreshToken,
                RefreshTokenExpiryTime = this.RefreshTokenExpiryTime,
            };
        }
    }
}
