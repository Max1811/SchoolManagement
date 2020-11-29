using Dapper;
using EducatoinManagement.DataAccessLayer.Contracts;
using EducatoinManagement.DataAccessLayer.Models;
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
    public class SchoolRepository: GenericCrudRepository<School>, ISchoolRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;
        public SchoolRepository(IConfiguration configuration)
            :base(configuration)
        {
            _configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
        }

        public async Task Delete(int id)
        {
            await Delete(id, "Schools");
        }

        public async Task<IActionResult> GeneratePrimaryData(int lowerBoundPerRegion, int UpperBoundPerRegion)
        {
            var procedure = "[GenerateRandomSchools]";
            var values = new { LowerBoundSchoolsPerRegion = lowerBoundPerRegion,
                UpperBoundSchoolsPerRegion = UpperBoundPerRegion };

            return await baseDataGeneringRepository.GenerateDataAsync(procedure, "[SchoolsSelectAll]", values);
        }

        public async Task<School> Get(int id)
        {
            return await Get(id, "Schools");
        }
    }
}
