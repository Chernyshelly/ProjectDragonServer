namespace Application.DTO.Request
{
    using Application.Interfaces;
    using Domain.Models;

    public class TeacherCreateRequestDto : IDtoMapper<Teacher>
    {
        public string FullName { get; set; }

        public string PersonalKey { get; set; }

        public Teacher ToModel()
        {
            return new Teacher()
            {
                FullName = this.FullName,
                PersonalKey = this.PersonalKey,
            };
        }
    }
}
