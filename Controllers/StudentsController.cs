using LibrarySystemWeb.Interfaces;
using LibrarySystemWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystemWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public IEnumerable<Student> GetAllStudents()
    {
        return _studentService.GetAll();
    }

    [HttpGet("{id}")]
    public IActionResult GetStudentById(int id)
    {
        var student = _studentService.GetById(id);
        if (student == null) return NotFound();
        return Ok(student);
    }

    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        _studentService.Add(student);
        return Created($"/students/{student.Id}", student);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, Student student)
    {
        if (id != student.Id) return BadRequest();

        _studentService.Update(student);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        _studentService.Delete(id);
        return NoContent();
    }
}