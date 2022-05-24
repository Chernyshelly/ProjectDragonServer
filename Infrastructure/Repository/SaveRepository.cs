namespace CleanArchitecture.Infra.Data.Repositories
{
    using System.Linq;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;

    public class SaveRepository : ISaveRepository
    {
        private DatabaseContext context;

        public SaveRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void DeleteSave(int id)
        {
            context.Saves.Remove(context.Saves.Where(x => x.Id == id).FirstOrDefault());
            context.SaveChanges();
        }

        public Save GetSaveByUsername(string username)
        {
            return context.Saves.Where(x => x.Player.Username == username).FirstOrDefault();
        }

        public Save NewSave(Save save)
        {
            var entity = context.Saves.Add(save);
            context.Attach(entity.Entity.Player);
            context.SaveChanges();
            return entity.Entity;
        }

        public Save UpdateSave(int id, string saveFileName)
        {
            var entity = context.Saves.Where(x => x.Id == id).FirstOrDefault();
            entity.SaveFileName = saveFileName;
            context.SaveChanges();
            return entity;
        }
    }
}
