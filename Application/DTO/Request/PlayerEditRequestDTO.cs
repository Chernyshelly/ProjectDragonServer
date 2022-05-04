namespace Application.DTO.Request
{
    using System;
    using Application.Interfaces;
    using Application.ViewModels;
    using Domain.Models;

    public class PlayerEditRequestDto : IDtoMapper<Player>
    {
        public PlayerEditRequestDto(PlayerDto player)
        {
            Id = player.Id;
            Username = player.Username;
            Password = player.Password;
            RefreshToken = player.RefreshToken;
            RefreshTokenExpiryTime = player.RefreshTokenExpiryTime;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public DateTime HighScore { get; set; }

        public Player ToModel()
        {
            return new Player()
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
