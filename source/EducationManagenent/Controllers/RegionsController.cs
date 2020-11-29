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
    public class RegionsController : Controller
    {
        private readonly IRegionsService regionsService;

        public RegionsController(IRegionsService regionsService)
        {
            this.regionsService = regionsService;
        }

        [HttpGet("{id}")]
        public async Task<Region> Get(int id)
        {
            return await regionsService.Get(id);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await regionsService.Delete(id);
        }
    }
}
