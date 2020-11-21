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
        public SchoolRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> GeneratePrimaryData(int lowerBoundPerRegion, int UpperBoundPerRegion)
        {
            var procedure = "[GenerateRandomSchools]";
            var values = new { LowerBoundSchoolsPerRegion = lowerBoundPerRegion,
                UpperBoundSchoolsPerRegion = UpperBoundPerRegion };
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    if (connection.QueryAsync("[SchoolsSelectAll]", null,
                        commandType: CommandType.StoredProcedure).Result.ToList().Count == 0)
                    {
                        await connection.QueryAsync(procedure, values, commandType: CommandType.StoredProcedure);
                        return new StatusCodeResult(201);
                    }

                    return new StatusCodeResult(208);
                }
                catch (Exception ex)
                {
                    // to do logging ex handling
                }
            }

            return new StatusCodeResult(400);
        }
    }
}
