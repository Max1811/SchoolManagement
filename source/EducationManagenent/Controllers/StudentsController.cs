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

        [HttpGet("get-all-students")]
        public async Task<IEnumerable<Student>> GetAllStudents()
        {
            IEnumerable<Student> students = await _studentsService.GetAllStudents();

            return students;
        }

        [HttpGet("{id}")]
        public async Task<Student> Get(int id)
        {
            return await _studentsService.GetStudentById(id);
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
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
