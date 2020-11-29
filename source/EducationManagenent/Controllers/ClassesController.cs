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
    public class ClassesController : Controller
    {
        private readonly IClassesService classesService;

        public ClassesController(IClassesService classesService)
        {
            this.classesService = classesService;
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await classesService.Delete(id);
        }

        [HttpGet("{id}")]
        public async Task<Class> Get(int id)
        {
            return await classesService.Get(id);
        }
    }
}
