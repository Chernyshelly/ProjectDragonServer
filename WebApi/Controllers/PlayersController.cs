namespace WebApi.Controllers
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Application.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
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

        [HttpGet("leaderboard")]
        public ActionResult<List<LeaderboardPlayerDto>> GetLeaderboard()
        {
            return this.Ok(_playerService.GetLeaderboardPlayers().Where(x => x.HighScore != 0).OrderBy(x => x.HighScore));
        }

        [Authorize]
        [HttpPost("save")]
        public async Task<ActionResult> FileAccept(IFormFile file)
        {
            if (file != null)
            {
                var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";

                // создаем папку для хранения файлов
                Directory.CreateDirectory(uploadPath);
                string fullPath = $"{uploadPath}/{file.FileName}";

                // сохраняем файл в папку uploads
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                return this.Ok();
            }

            return this.NoContent();
        }

        [Authorize]
        [HttpGet("save")]
        public FileStreamResult GetSave()
        {
            var fileName = User.Identity.Name;
            var mimeType = "application/octet-stream";
            var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads/{User.Identity.Name}";
            var fileStream = new FileStream(uploadPath, FileMode.Open);

            return new FileStreamResult(fileStream, mimeType)
            {
                FileDownloadName = fileName,
            };
        }

        [HttpPost("register")]
        public ActionResult<PlayerDto> Register([FromBody] LoginModel player)
        {
            if (!_playerService.GetPlayers().Where(x => x.Username == player.UserName).Any())
            {
                var resPlayer = new PlayerCreateRequestDto();
                resPlayer.Username = player.UserName;
                resPlayer.Password = Hash.HMACHASH(player.Password, Hash.Key);
                return this.Ok(_playerService.InsertPlayer(resPlayer));
            }
            else
            {
                return this.Conflict();
            }
        }

        [HttpPost]
        public ActionResult<PlayerDto> Insert([FromBody] PlayerCreateRequestDto player)
        {
            return this.Ok(_playerService.InsertPlayer(player));
        }
    }
}
