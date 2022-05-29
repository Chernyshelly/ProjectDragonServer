namespace WebApi.Controllers
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class SaveController : ControllerBase
    {
        private readonly ILogger<SaveController> logger;
        private ISaveService _saveService;
        private IPlayerService _playerService;

        public SaveController(ILogger<SaveController> logger, ISaveService saveService, IPlayerService playerService)
        {
            this.logger = logger;
            this._saveService = saveService;
            this._playerService = playerService;
        }

        [Authorize]
        [HttpPost("UploadSave")]
        public async Task<ActionResult> SaveFileAccept(IFormFile file)
        {
            if (file != null)
            {
                var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";

                // создаем папку для хранения файлов
                Directory.CreateDirectory(uploadPath);
                string fullPath = $"{uploadPath}/{User.Identity.Name}";

                // сохраняем файл в папку uploads
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var save = _saveService.GetSaveByUsername(User.Identity.Name);
                if (save != null)
                {
                    _saveService.UpdateSave(save.Id, User.Identity.Name, null);
                }
                else
                {
                    _saveService.NewSave(new SaveCreateRequestDto
                    {
                        Player = _playerService.GetPlayers().Where(x => x.Username == User.Identity.Name).FirstOrDefault().ToModel(),
                        SaveFileName = User.Identity.Name,
                    });
                }

                return this.Ok();
            }

            return this.NoContent();
        }

        [Authorize]
        [HttpGet("DownloadSave")]
        public FileStreamResult GetSave()
        {
            var save = _saveService.GetSaveByUsername(User.Identity.Name);
            if (save is not null)
            {
                var fileName = save.SaveFileName;
                var mimeType = "application/octet-stream";
                var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads/{fileName}";
                var fileStream = new FileStream(uploadPath, FileMode.Open);

                return new FileStreamResult(fileStream, mimeType)
                {
                    FileDownloadName = fileName,
                };
            }
            else
            {
                // Should return error code on release
                return null;
            }
        }

        [Authorize]
        [HttpPost("UploadSkillSave")]
        public async Task<ActionResult> SkillSaveFileAccept(IFormFile file)
        {
            if (file != null)
            {
                var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads";

                // создаем папку для хранения файлов
                Directory.CreateDirectory(uploadPath);
                string fullPath = $"{uploadPath}/{User.Identity.Name}Skills";

                // сохраняем файл в папку uploads
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                var save = _saveService.GetSaveByUsername(User.Identity.Name);
                if (save != null)
                {
                    _saveService.UpdateSave(save.Id, null, User.Identity.Name + "Skills");
                }
                else
                {
                    _saveService.NewSave(new SaveCreateRequestDto
                    {
                        Player = _playerService.GetPlayers().Where(x => x.Username == User.Identity.Name).FirstOrDefault().ToModel(),
                        SkillSaveFileName = User.Identity.Name + "Skills",
                    });
                }

                return this.Ok();
            }

            return this.NoContent();
        }

        [Authorize]
        [HttpGet("DownloadSkillSave")]
        public FileStreamResult GetSkillSave()
        {
            var save = _saveService.GetSaveByUsername(User.Identity.Name);
            if (save is not null)
            {
                var fileName = save.SkillSaveFileName;
                var mimeType = "application/octet-stream";
                var uploadPath = $"{Directory.GetCurrentDirectory()}/uploads/{fileName}";
                var fileStream = new FileStream(uploadPath, FileMode.Open);

                return new FileStreamResult(fileStream, mimeType)
                {
                    FileDownloadName = fileName,
                };
            }
            else
            {
                // Should return error code on release
                return null;
            }
        }
    }
}
