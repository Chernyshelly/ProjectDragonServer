namespace Application.ViewModels
{
    using Domain.Models;

    public class PlayerDto
    {
        public PlayerDto(Player teacher)
        {
            this.Id = teacher.Id;
            this.Username = teacher.Username;
            this.Password = teacher.Password;
        }

        public PlayerDto()
        {
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
