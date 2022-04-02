namespace Application.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.DTO.Request;
    using Application.Interfaces;
    using Application.ViewModels;
    using Domain.Repository;

    public class TeacherService : ITeacherService
    {
        private ITeacherRepository _teacherRepository;

        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public List<TeacherDto> GetTeachers()
        {
            return _teacherRepository.GetTeachers().Select(x => new TeacherDto(x)).ToList();
        }

        public TeacherDto InsetTeacher(TeacherCreateRequestDto teacher)
        {
            var createdTeacher = new TeacherDto(_teacherRepository.InsertTeacher(teacher.ToModel()));
            return createdTeacher;
        }
    }
}
