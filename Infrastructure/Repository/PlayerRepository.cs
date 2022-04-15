namespace CleanArchitecture.Infra.Data.Repositories
{
    using System.Linq;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;
    using Microsoft.EntityFrameworkCore;

    public class PlayerRepository : IPlayerRepository
    {
        private DatabaseContext context;

        public PlayerRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public Player InsertPlayer(Player player)
        {
            var entity = context.Add(player);
            context.SaveChanges();
            return entity.Entity;
        }

        IQueryable<Player> IPlayerRepository.GetPlayers()
        {
            return context.Players.AsNoTracking();
        }
    }
}
