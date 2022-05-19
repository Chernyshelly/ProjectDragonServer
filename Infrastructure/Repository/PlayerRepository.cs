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

        public Player EditPlayer(Player player)
        {
            var entity = context.Players.FirstOrDefault(x => x.Id == player.Id);
            if (player.Username is not null)
            {
                entity.Username = player.Username;
            }

            if (player.Password is not null)
            {
                entity.Password = player.Password;
            }

            entity.RefreshToken = player.RefreshToken;
            entity.RefreshTokenExpiryTime = player.RefreshTokenExpiryTime;
            if (player.HighScore != 0)
            {
                entity.HighScore = player.HighScore;
            }

            context.SaveChanges();
            return entity;
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
