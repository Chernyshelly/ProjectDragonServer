namespace Domain.Repository
{
    using System.Linq;
    using Domain.Models;

    public interface IPlayerRepository
    {
        IQueryable<Player> GetPlayers();

        Player InsertPlayer(Player player);

        Player EditPlayer(Player player);
    }
}
