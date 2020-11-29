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
    public class GradesController : Controller
    {
        private readonly IGradesService gradesService;

        public GradesController(IGradesService gradesService)
        {
            this.gradesService = gradesService;
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await gradesService.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<Grade> Get(int id)
        {
            return await gradesService.Get(id);
        }
    }
}
