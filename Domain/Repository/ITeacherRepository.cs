namespace Domain.Repository
{
    using System.Linq;
    using Domain.Models;

    public interface ITeacherRepository
    {
        IQueryable<Teacher> GetTeachers();

        Teacher InsertTeacher(Teacher teacher);
    }
}
