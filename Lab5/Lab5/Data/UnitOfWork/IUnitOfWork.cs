using Lab5.Data.Repository;
using Lab5.Models;

namespace Lab5.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<Student> Students { get; }
    IRepository<Teacher> Teachers { get; }
    IRepository<Grade> Grades { get; }
    IRepository<Course> Courses { get; }
    int Complete();
}
