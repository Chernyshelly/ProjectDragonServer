namespace Application.ViewModels
{
    using System;
    using Domain.Models;

    public class PlayerDto
    {
        public PlayerDto(Player player)
        {
            this.Id = player.Id;
            this.Username = player.Username;
            this.Password = player.Password;
            this.RefreshToken = player.RefreshToken;
            this.RefreshTokenExpiryTime = player.RefreshTokenExpiryTime;
        }

        public PlayerDto()
        {
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
