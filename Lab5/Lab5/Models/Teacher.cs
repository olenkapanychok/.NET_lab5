namespace Lab5.Models;

public class Teacher
{
    public int TeacherId { get; set; }
    public string? Name { get; set; }
    public List<Course>? Courses { get; set; }
}