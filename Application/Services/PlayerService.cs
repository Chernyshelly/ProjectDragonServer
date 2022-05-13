namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Application.ViewModels;
    using Domain.Repository;

    public class PlayerService : IPlayerService
    {
        private IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public PlayerDto EditPlayer(PlayerEditRequestDto player)
        {
            var resultPlayer = new PlayerDto(_playerRepository.EditPlayer(player.ToModel()));
            return resultPlayer;
        }

        public List<PlayerDto> GetPlayers()
        {
            return _playerRepository.GetPlayers().Select(x => new PlayerDto(x)).ToList();
        }

        public List<LeaderboardPlayerDto> GetLeaderboardPlayers()
        {
            return _playerRepository.GetPlayers().Select(x => new LeaderboardPlayerDto(x)).ToList();
        }

        public PlayerDto InsertPlayer(PlayerCreateRequestDto player)
        {
            var createdPlayer = new PlayerDto(_playerRepository.InsertPlayer(player.ToModel()));
            return createdPlayer;
        }
    }
}
