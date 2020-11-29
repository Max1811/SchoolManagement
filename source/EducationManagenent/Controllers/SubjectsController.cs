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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectsService subjectsService;

        public SubjectsController(ISubjectsService subjectsService)
        {
            this.subjectsService = subjectsService;
        }

        [HttpGet("id")]
        public async Task<Subject> Get(int id)
        {
            return await subjectsService.Get(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await subjectsService.Delete(id);
        }

        [HttpGet("get-all")]
        public async Task<IEnumerable<Subject>> GetAll()
        {
            return await subjectsService.GetAllAsync();
        }
    }
}
