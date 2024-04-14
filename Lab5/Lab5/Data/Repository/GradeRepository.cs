using Lab5.Models;

namespace Lab5.Data.Repository;

public class GradeRepository: Repository<Grade>, IGradeRepository
{
    public GradeRepository(AppDbContext context) : base(context)
    {
    }
}