namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Application.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> logger;
        private IPlayerService _playerService;

        public PlayersController(ILogger<PlayersController> logger, IPlayerService playerService)
        {
            this.logger = logger;
            _playerService = playerService;
        }

        [HttpGet]
        public ActionResult<List<PlayerDto>> Get()
        {
            return this.Ok(_playerService.GetPlayers());
        }

        [HttpPost]
        public ActionResult<PlayerDto> Insert([FromBody] PlayerCreateRequestDto player)
        {
            return this.Ok(_playerService.InsertPlayer(player));
        }
    }
}
