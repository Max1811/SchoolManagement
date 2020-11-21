using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EducationManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EducationManagenent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitializeWithPrimaryDataController : ControllerBase
    {
        private readonly IRegionsService regionsService;
        private readonly ISchoolsService schoolsService;
        private readonly IClassesService classesService;
        public InitializeWithPrimaryDataController(IRegionsService regionsService
            , ISchoolsService schoolsService, IClassesService classesService)
        {
            this.regionsService = regionsService;
            this.schoolsService = schoolsService;
            this.classesService = classesService;
        }

        [HttpPost("init-regions")]
        public async Task<IActionResult> InitializeRegions(int regionsNumber)
        {
            return await regionsService.GenerateRandomData(regionsNumber);
        }

        [HttpPost("init-schools")]
        public async Task<IActionResult> InitializeSchools(int lowerBoundPerRegion, int UpperBoundPerRegion)
        {
            return await schoolsService.GenerateRandomData(lowerBoundPerRegion, UpperBoundPerRegion);
        }

        [HttpPost("init-classes")]
        public async Task<IActionResult> InitializeClasses(int maxAmountOfParalelClasses)
        {
            return await classesService.GenerateRandomData(maxAmountOfParalelClasses);
        }
    }
}
