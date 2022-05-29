namespace Application.DTO.Request
{
    using Application.Interfaces;
    using Domain.Models;

    public class SaveCreateRequestDto : IDtoMapper<Save>
    {
        public Player Player { get; set; }

        public string SaveFileName { get; set; }

        public string SkillSaveFileName { get; set; }

        public Save ToModel()
        {
            return new Save
            {
                Player = this.Player,
                SaveFileName = this.SaveFileName,
                SkillSaveFileName = this.SkillSaveFileName,
            };
        }
    }
}
