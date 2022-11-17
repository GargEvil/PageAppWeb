﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PageAppWeb.DTOs;
using PageAppWeb.Services;

namespace PageAppWeb.Controllers;
[Route("api/student")]
[ApiController]
[Authorize]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("get")]
    public async Task<ActionResult> Get()
    {
        return Ok(await _studentService.GetAllStudents());
    }

    [HttpPost("post")]
    public async Task<ActionResult> Add([FromBody] StudentDTO student)
    {
        await _studentService.AddStudent(student);
        return Ok();
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult> Update([FromRoute] int id, [FromBody] StudentDTO student)
    {
        return Ok(await _studentService.UpdateStudent(id, student));
    }

    [HttpDelete("delete/{id}")]
    public async Task<ActionResult> Delete([FromRoute] int id)
    {
        await _studentService.DeleteStudent(id);
        return Ok();
    }
}
