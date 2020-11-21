using EducationManagement.Services.Interfaces;
using EducatoinManagement.DataAccessLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Implementations
{
    public class SchoolsService : ISchoolsService
    {
        private readonly ISchoolRepository schoolRepository;
        public SchoolsService(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }
        public async Task<IActionResult> GenerateRandomData(int lowerBoundPerRegion, int UpperBoundPerRegion)
        {
            return await schoolRepository.GeneratePrimaryData(lowerBoundPerRegion, UpperBoundPerRegion); 
        }
    }
}
