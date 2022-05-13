namespace Application.Interfaces
{
    using System.Collections.Generic;
    using Application.DTO.Request;
    using Application.ViewModels;

    public interface IPlayerService
    {
        List<PlayerDto> GetPlayers();

        public List<LeaderboardPlayerDto> GetLeaderboardPlayers();

        public PlayerDto EditPlayer(PlayerEditRequestDto player);

        PlayerDto InsertPlayer(PlayerCreateRequestDto player);
    }
}
