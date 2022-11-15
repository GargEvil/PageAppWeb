using Microsoft.AspNetCore.Mvc;
using PageApp.Infrastracture.Models;
using PageAppWeb.Services;

namespace PageAppWeb.Controllers;
[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet(Name = "GetAllStudents")]
    public async Task<List<Student>> Get()
    {
        return await _studentService.GetAllStudents();
    }
}
