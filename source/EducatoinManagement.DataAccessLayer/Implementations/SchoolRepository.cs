using Dapper;
using EducatoinManagement.DataAccessLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Implementations
{
    public class SchoolRepository: ISchoolRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;
        public SchoolRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
        }

        public async Task<IActionResult> GeneratePrimaryData(int lowerBoundPerRegion, int UpperBoundPerRegion)
        {
            var procedure = "[GenerateRandomSchools]";
            var values = new { LowerBoundSchoolsPerRegion = lowerBoundPerRegion,
                UpperBoundSchoolsPerRegion = UpperBoundPerRegion };

            return await baseDataGeneringRepository.GenerateDataAsync(procedure, "[SchoolsSelectAll]", values);
        }
    }
}
