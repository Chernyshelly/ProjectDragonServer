namespace Application.Interfaces
{
    using System.Collections.Generic;
    using Application.DTO.Request;
    using Application.ViewModels;

    public interface ITeacherService
    {
        List<TeacherDto> GetTeachers();

        TeacherDto InsetTeacher(TeacherCreateRequestDto teacher);
    }
}
