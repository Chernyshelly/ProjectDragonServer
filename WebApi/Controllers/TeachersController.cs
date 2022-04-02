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
    public class TeachersController : ControllerBase
    {
        private readonly ILogger<TeachersController> logger;
        private ITeacherService _teacherService;

        public TeachersController(ILogger<TeachersController> logger, ITeacherService teacherService)
        {
            this.logger = logger;
            _teacherService = teacherService;
        }

        [HttpGet]
        public ActionResult<List<TeacherDto>> Get()
        {
            return this.Ok(_teacherService.GetTeachers());
        }

        [HttpPost]
        public ActionResult<TeacherDto> Insert([FromBody] TeacherCreateRequestDto teacher)
        {
            return this.Ok(_teacherService.InsetTeacher(teacher));
        }
    }
}
