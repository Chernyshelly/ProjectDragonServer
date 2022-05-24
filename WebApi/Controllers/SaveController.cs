namespace WebApi.Controllers
{
    using System.IO;
    using System.Threading.Tasks;
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

        public SaveController(ILogger<SaveController> logger, ISaveService saveService)
        {
            this.logger = logger;
            this._saveService = saveService;
        }

        [Authorize]
        [HttpPost("Upload")]
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
        [HttpGet("Download")]
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
    }
}
