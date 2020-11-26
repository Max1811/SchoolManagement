using EducatoinManagement.DataAccessLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Implementations
{
    public class GradesRepository : IGradesRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;
        public GradesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
        }

        public async Task<IActionResult> GeneratePrimaryData(int lowerBound, int upperBound, int numberOfGradesPerStudent)
        {
            var procedure = "[GenerateRandomGrades]";
            var values = new
            {
                LowerGradeBound = lowerBound,
                UpperGradeBound = upperBound,
                GradesForStudents = numberOfGradesPerStudent
            };

            return await baseDataGeneringRepository.GenerateDataAsync(procedure, "[GradesSelectAny]", values);
        }
    }
}
