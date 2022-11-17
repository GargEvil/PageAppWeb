using Microsoft.AspNetCore.Mvc;
using PageAppWeb.DTOs;
using PageAppWeb.Services;

namespace PageAppWeb.Controllers;

[Route("api/course")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("get")]
    public async Task<ActionResult> Get()
    {
        return Ok(await _courseService.GetAll());
    }

    [HttpPost("post")]
    public async Task<ActionResult> Add([FromBody] CourseDTO student)
    {
        await _courseService.AddCourse(student);
        return Ok();
    }
}
