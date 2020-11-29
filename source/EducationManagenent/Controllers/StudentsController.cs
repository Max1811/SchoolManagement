using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationManagement.Services.Interfaces;
using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EducationManagenent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = studentsService;
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<Student>> GetAll()
        {
            IEnumerable<Student> students = await _studentsService.GetAllStudentsAsync();

            return students;
        }

        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            return await _studentsService.Get(id);
        }

        [HttpPost("create-student")]
        public async Task<IActionResult> Post(string firstName, string lastName, string Patronymic, int age, int classId)
        {
            try
            {
                await _studentsService.InsertStudent(firstName, lastName, Patronymic, age, classId);
                return new StatusCodeResult(201);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(400);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _studentsService.DeleteStudentById(id);
        }
    }
}
