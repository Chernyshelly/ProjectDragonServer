namespace Application.ViewModels
{
    using Domain.Models;

    public class TeacherDto
    {
        public TeacherDto(Teacher teacher)
        {
            this.Id = teacher.Id;
            this.FullName = teacher.FullName;
            this.PersonalKey = teacher.PersonalKey;
        }

        public TeacherDto()
        {
        }

        public int Id { get; set; }

        public string FullName { get; set; }

        public string PersonalKey { get; set; }
    }
}
