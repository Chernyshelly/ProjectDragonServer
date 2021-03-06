namespace Application.DTO.Responce
{
    using Domain.Models;

    public class SaveDto
    {
        public SaveDto(Save save)
        {
            Id = save.Id;
            Player = save.Player;
            SaveFileName = save.SaveFileName;
            SkillSaveFileName = save.SkillSaveFileName;
        }

        public int Id { get; set; }

        public Player Player { get; set; }

        public string SaveFileName { get; set; }

        public string SkillSaveFileName { get; set; }
    }
}
