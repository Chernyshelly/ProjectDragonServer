namespace Application.Interfaces
{
    using System.Collections.Generic;
    using Application.DTO.Request;
    using Application.ViewModels;

    public interface IPlayerService
    {
        List<PlayerDto> GetPlayers();

        PlayerDto InsetPlayer(PlayerCreateRequestDto player);
    }
}
