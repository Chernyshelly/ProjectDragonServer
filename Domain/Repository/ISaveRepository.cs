namespace Domain.Repository
{
    using Domain.Models;

    public interface ISaveRepository
    {
        public Save GetSaveByUsername(string username);

        public void NewSave(Save save);

        public void DeleteSave(int id);

        public void UpdateSave(int id, string saveFileName);
    }
}
