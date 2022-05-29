namespace Domain.Repository
{
    using Domain.Models;

    public interface ISaveRepository
    {
        public Save GetSaveByUsername(string username);

        public Save NewSave(Save save);

        public void DeleteSave(int id);

        public Save UpdateSave(int id, string saveFileName, string skillSaveFileName);
    }
}
