using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EducationManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EducationManagenent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitializeWithPrimaryDataController : ControllerBase
    {
        private readonly IRegionsService regionsService;
        private readonly ISchoolsService schoolsService;
        private readonly IClassesService classesService;
        private readonly ISubjectsService subjectsService;
        private readonly IStudentsService studentsService;
        private readonly IStudentsSubjectsService studentsSubjectsService;
        private readonly IGradesService gradesService;
        public InitializeWithPrimaryDataController(IRegionsService regionsService, 
            ISchoolsService schoolsService, IClassesService classesService,
            ISubjectsService subjectsService, IStudentsService studentsService,
            IStudentsSubjectsService studentsSubjectsService, IGradesService gradesService)
        {
            this.regionsService = regionsService;
            this.schoolsService = schoolsService;
            this.classesService = classesService;
            this.subjectsService = subjectsService;
            this.studentsService = studentsService;
            this.studentsSubjectsService = studentsSubjectsService;
            this.gradesService = gradesService;
        }

        [HttpPost("generate-data")]
        public async Task<IActionResult> GenerateData(int regionsNumber, int lowerBoundPerRegion,
            int UpperBoundPerRegion, int maxAmountOfParalelClasses, int subjectsCount,
            int minStudentPerClassCount, int maxStudentsPerClassCount, int subjectsPerStudent,
            int lowerGradeBound, int upperGradeBound, int numberOfGradesPerStudents)
        {
            try
            {
                await regionsService.GenerateRandomData(regionsNumber);
                await schoolsService.GenerateRandomData(lowerBoundPerRegion, UpperBoundPerRegion);
                await classesService.GenerateRandomData(maxAmountOfParalelClasses);
                await subjectsService.GenerateRandomData(subjectsCount);
                await studentsService.GenerateRandomData(minStudentPerClassCount, maxStudentsPerClassCount);
                await studentsSubjectsService.GenerateRandomData(subjectsPerStudent);
                await gradesService.GenerateRandomData(lowerGradeBound, upperGradeBound, numberOfGradesPerStudents);

                return new StatusCodeResult(201);
            }
            catch(Exception ex)
            {
                return new StatusCodeResult(400);
            }
            
        }
    }
}
