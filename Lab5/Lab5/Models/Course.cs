namespace Lab5.Models;

public class Course
{
    public int CourseId { get; set; }
    public string? Title { get; set; }
    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public List<Grade>? Grades { get; set; }
}