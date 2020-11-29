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
    public class StudentsSubjectsController : ControllerBase
    {
        private readonly IStudentsSubjectsService studentsSubjectsService;

        public StudentsSubjectsController(IStudentsSubjectsService studentsSubjectsService)
        {
            this.studentsSubjectsService = studentsSubjectsService;
        }

        [HttpGet("id")]
        public async Task<StudentSubject> Get(int id)
        {
            return await studentsSubjectsService.Get(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await studentsSubjectsService.Delete(id);
        }
    }
}
