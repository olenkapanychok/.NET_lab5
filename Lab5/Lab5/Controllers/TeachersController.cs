using AutoMapper;
using Lab5.Data.UnitOfWork;
using Lab5.DTOs.InputDTOs;
using Lab5.DTOs.OutputDTOs;
using Lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeachersController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public TeachersController(IUnitOfWork unitOfWork,  IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var teachers = _unitOfWork.Teachers.GetAll();
        return Ok(_mapper.Map<IEnumerable<TeacherOutputDto>>(teachers));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var teacher = _unitOfWork.Teachers.Get(id);
        if (teacher == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<TeacherOutputDto>(teacher));

    }

    [HttpPost]
    public IActionResult Create([FromBody] TeacherInputDto teacher)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<Teacher>(teacher);
            _unitOfWork.Teachers.Add(entity);
            _unitOfWork.Complete();
            return Ok();
        }
        return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, [FromBody] TeacherInputDto teacher)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<Teacher>(teacher);
            _unitOfWork.Teachers.Update(id,entity);
            _unitOfWork.Complete();
            return NoContent();
        }
        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var teacher = _unitOfWork.Teachers.Get(id);
        if (teacher == null)
        {
            return NotFound();
        }

        _unitOfWork.Teachers.Remove(teacher);
        _unitOfWork.Complete();
        return NoContent();
    }
}