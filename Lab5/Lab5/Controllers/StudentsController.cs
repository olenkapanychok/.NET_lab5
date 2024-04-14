using AutoMapper;
using Lab5.Data.UnitOfWork;
using Lab5.DTOs.InputDTOs;
using Lab5.DTOs.OutputDTOs;
using Lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentsController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var students = _unitOfWork.Students.GetAll();
        return Ok(_mapper.Map<IEnumerable<StudentOutputDto>>(students));
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var student = _unitOfWork.Students.Get(id);
        if (student == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<StudentOutputDto>(student));
    }

    [HttpPost]
    public IActionResult Create([FromBody] StudentInputDto student)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<Student>(student);
            _unitOfWork.Students.Add(entity);
            _unitOfWork.Complete();
            return Ok();
        }
        return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, [FromBody] StudentInputDto student)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<Student>(student);
            _unitOfWork.Students.Update(id, entity);
            _unitOfWork.Complete();
            return NoContent();
        }
        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var student = _unitOfWork.Students.Get(id);
        if (student == null)
        {
            return NotFound();
        }

        _unitOfWork.Students.Remove(student);
        _unitOfWork.Complete();
        return NoContent();
    }
}