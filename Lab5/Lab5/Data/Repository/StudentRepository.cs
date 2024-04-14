using Lab5.Models;

namespace Lab5.Data.Repository;

public class StudentRepository: Repository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext context) : base(context)
    {
    }
}