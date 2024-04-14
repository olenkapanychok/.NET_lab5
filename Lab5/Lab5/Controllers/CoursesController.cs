using AutoMapper;
using Lab5.Data.UnitOfWork;
using Lab5.DTOs.InputDTOs;
using Lab5.DTOs.OutputDTOs;
using Lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public CoursesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var courses = _unitOfWork.Courses.GetAll();
        return Ok(_mapper.Map<IEnumerable<CourseOutputDto>>(courses));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var course = _unitOfWork.Courses.Get(id);
        if (course == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<CourseOutputDto>(course));

    }

    [HttpPost]
    public IActionResult Create([FromBody] CourseInputDto course)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<Course>(course);
            _unitOfWork.Courses.Add(entity);
            _unitOfWork.Complete();
            return Ok();
        }
        return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, [FromBody] CourseInputDto course)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<Course>(course);
            _unitOfWork.Courses.Update(id,entity);
            _unitOfWork.Complete();
            return NoContent();
        }
        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var course = _unitOfWork.Courses.Get(id);
        if (course == null)
        {
            return NotFound();
        }

        _unitOfWork.Courses.Remove(course);
        _unitOfWork.Complete();
        return NoContent();
    }
}