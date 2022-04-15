namespace Application.DTO.Request
{
    using Application.Interfaces;
    using Domain.Models;

    public class PlayerCreateRequestDto : IDtoMapper<Player>
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public Player ToModel()
        {
            return new Player()
            {
                Username = this.Username,
                Password = this.Password,
            };
        }
    }
}
