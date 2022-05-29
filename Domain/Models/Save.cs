namespace Domain.Models
{
    public class Save
    {
        public int Id { get; set; }

        public Player Player { get; set; }

        public string SaveFileName { get; set; }

        public string SkillSaveFileName { get; set; }
    }
}
