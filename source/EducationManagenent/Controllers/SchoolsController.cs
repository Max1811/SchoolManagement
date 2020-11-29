using EducationManagement.Services.Interfaces;
using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationManagenent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : Controller
    {
        private readonly ISchoolsService schoolsService;

        public SchoolsController(ISchoolsService schoolsService)
        {
            this.schoolsService = schoolsService;
        }

        [HttpGet("{id}")]
        public async Task<School> Get(int id)
        {
            return await schoolsService.Get(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await schoolsService.Delete(id);
        }
    }
}
