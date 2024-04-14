using Lab5.Data.Repository;
using Lab5.Models;

namespace Lab5.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    public IRepository<Student> Students { get; }
    public IRepository<Teacher> Teachers { get; }
    public IRepository<Grade> Grades { get; }
    public IRepository<Course> Courses { get; }

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
        Students = new Repository<Student>(_context);
        Teachers = new Repository<Teacher>(_context);
        Grades = new Repository<Grade>(_context);
        Courses = new Repository<Course>(_context);
    }

    public int Complete() => _context.SaveChanges();
    public void Dispose() => _context.Dispose();
}