namespace Lab5.Models;

public class Student
{
    public int StudentId { get; set; }
    public string? Name { get; set; }
    public List<Grade>? Grades { get; set; }
}