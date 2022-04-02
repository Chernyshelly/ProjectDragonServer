namespace CleanArchitecture.Infra.Data.Repositories
{
    using System.Linq;
    using Domain.Models;
    using Domain.Repository;
    using Infrastructure.EF;

    // using Microsoft.EntityFrameworkCore;
    public class TeacherRepository : ITeacherRepository
    {
        private DatabaseContext context;

        public TeacherRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public Teacher InsertTeacher(Teacher teacher)
        {
            var entity = context.Add(teacher);
            context.SaveChanges();
            return entity.Entity;
        }

        IQueryable<Teacher> ITeacherRepository.GetTeachers()
        {
            return null; // return context.Teachers.AsNoTracking();
        }
    }
}
