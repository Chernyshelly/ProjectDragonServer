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

        public List<PlayerDto> GetPlayers()
        {
            return _playerRepository.GetPlayers().Select(x => new PlayerDto(x)).ToList();
        }

        public PlayerDto InsetPlayer(PlayerCreateRequestDto player)
        {
            var createdPlayer = new PlayerDto(_playerRepository.InsertPlayer(player.ToModel()));
            return createdPlayer;
        }
    }
}
