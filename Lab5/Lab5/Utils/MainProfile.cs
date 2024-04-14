using AutoMapper;
using Lab5.DTOs.InputDTOs;
using Lab5.DTOs.OutputDTOs;
using Lab5.Models;

namespace Lab5.Utils;

public class MainProfile: Profile
{
    public MainProfile()
    {
        CreateMap<CourseInputDto, Course>();
        CreateMap<Course, CourseOutputDto>();
        
        CreateMap<GradeInputDto, Grade>();
        CreateMap<Grade, GradeOutputDto>();
        
        CreateMap<StudentInputDto, Student>();
        CreateMap<Student, StudentOutputDto>();
        
        CreateMap<TeacherInputDto, Teacher>();
        CreateMap<Teacher, TeacherOutputDto>();
    }
    
}