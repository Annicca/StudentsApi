using Lessons9.DTO;
using Lessons9.Interfaces;
using Lessons9.Models;
using Lessons9.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

namespace Lessons9.Controllers
{
    [ApiController]
    [Route("students-api")]
    public class StudentApiController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentApiController(
            IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await studentService.GetAll());
        }
        
        [HttpGet("search")]
        public async Task<IActionResult> Search(string? group)
        {
            return Ok(await studentService.Search(group));
        }

        [HttpGet("transaction")]
        public async Task<IActionResult> Tr(string? group)
        {
            try {
                await studentService.Transaction();
                return Ok();
            }
            catch(Exception ex) {
                return Conflict(new { message = ex.Message });
            }
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await studentService.GetById(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        //[Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDto dto)
        {
            var student = await studentService.Create(dto);

            if (student is null)
            {
                return BadRequest();
            }

            return Ok(student);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, UpdateStudentDto updatedStudent)
        {
            var student = await studentService.Update(id, updatedStudent);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var isStudent = await studentService.Delete(id);
                if (!isStudent)
                {
                    return NotFound();
                }

                return Ok();

            }
            catch (Exception ex)
            {
                return Conflict(new { message = ex.Message });
            }
            
        }


    }
}