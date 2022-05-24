namespace Application.ViewModels
{
    using System;
    using Application.Interfaces;
    using Domain.Models;

    public class PlayerDto : IDtoMapper<Player>
    {
        public PlayerDto(Player player)
        {
            this.Id = player.Id;
            this.Username = player.Username;
            this.Password = player.Password;
            this.RefreshToken = player.RefreshToken;
            this.RefreshTokenExpiryTime = player.RefreshTokenExpiryTime;
            this.HighScore = player.HighScore;
        }

        public PlayerDto()
        {
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public int HighScore { get; set; }

        public Player ToModel()
        {
            return new Player
            {
                Id = this.Id,
                Username = this.Username,
                Password = this.Password,
                RefreshToken = this.RefreshToken,
                RefreshTokenExpiryTime = this.RefreshTokenExpiryTime,
                HighScore = this.HighScore,
            };
        }
    }
}
