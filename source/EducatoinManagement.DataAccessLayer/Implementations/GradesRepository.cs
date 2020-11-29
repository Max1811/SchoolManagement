using Dapper;
using EducatoinManagement.DataAccessLayer.Contracts;
using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Implementations
{
    public class GradesRepository : GenericCrudRepository<Grade>, IGradesRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;
        public GradesRepository(IConfiguration configuration)
            :base(configuration)
        {
            _configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
        }

        public async Task Delete(int id)
        {
            await Delete(id, "Grades");
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

        public async Task<Grade> Get(int id)
        {
            return await Get(id, "Grades");
        }
    }
}
