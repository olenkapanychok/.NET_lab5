using Lab5.Models;

namespace Lab5.Data.Repository;

public class CourseRepository: Repository<Course>, ICourseRepository
{
    public CourseRepository(AppDbContext context) : base(context)
    {
    }
}