using Lab5.Models;

namespace Lab5.Data.Repository;

public class TeacherRepository: Repository<Teacher>, ITeacherRepository
{
    public TeacherRepository(AppDbContext context) : base(context)
    {
    }
}