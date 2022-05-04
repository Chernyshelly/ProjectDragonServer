namespace Domain.Models
{
    using System;

    public class Player
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpiryTime { get; set; }

        public DateTime HighScore { get; set; } = new DateTime(1970, 1, 1);
    }
}
