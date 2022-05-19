namespace Application.ViewModels
{
    using System;
    using Domain.Models;

    public class LeaderboardPlayerDto
    {
        public LeaderboardPlayerDto(Player player)
        {
            this.Username = player.Username;
            this.HighScore = player.HighScore;
        }

        public LeaderboardPlayerDto()
        {
        }

        public string Username { get; set; }

        public int HighScore { get; set; }
    }
}
