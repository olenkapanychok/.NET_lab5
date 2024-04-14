using AutoMapper;
using Lab5.Data.UnitOfWork;
using Lab5.DTOs.InputDTOs;
using Lab5.DTOs.OutputDTOs;
using Lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GradesController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GradesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var grades = _unitOfWork.Students.GetAll();
        return Ok(_mapper.Map<IEnumerable<GradeOutputDto>>(grades));

    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var grade = _unitOfWork.Grades.Get(id);
        if (grade == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<GradeOutputDto>(grade));

    }

    [HttpPost]
    public IActionResult Create([FromBody] GradeInputDto grade)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<Grade>(grade);
            _unitOfWork.Grades.Add(entity);
            _unitOfWork.Complete();
            return Ok();
        }
        return BadRequest(ModelState);
    }

    [HttpPut("{id}")]
    public IActionResult Edit(int id, [FromBody] GradeInputDto grade)
    {
        if (ModelState.IsValid)
        {
            var entity = _mapper.Map<Grade>(grade);
            _unitOfWork.Grades.Update(id,entity);
            _unitOfWork.Complete();
            return NoContent();
        }
        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var grade = _unitOfWork.Grades.Get(id);
        if (grade == null)
        {
            return NotFound();
        }

        _unitOfWork.Grades.Remove(grade);
        _unitOfWork.Complete();
        return NoContent();
    }
}