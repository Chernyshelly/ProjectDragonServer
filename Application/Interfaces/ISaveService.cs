namespace Application.Interfaces
{
    using Application.DTO.Request;
    using Application.DTO.Responce;

    public interface ISaveService
    {
        public SaveDto GetSaveByUsername(string username);

        public SaveDto NewSave(SaveCreateRequestDto save);

        public void DeleteSave(int id);

        public SaveDto UpdateSave(int id, string saveFileName, string skillSaveFileName);
    }
}
