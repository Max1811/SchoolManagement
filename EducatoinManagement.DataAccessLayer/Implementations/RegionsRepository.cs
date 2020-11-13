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
    public class RegionsRepository : IRegionsRepository
    {
        private readonly IConfiguration _configuration;
        public RegionsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> GeneratePrimaryData(int numberOfRegions, CancellationToken cancellationToken = default)
        {
            var procedure = "[GenerateRandomRegions]";
            var values = new { RegionsCount = numberOfRegions };
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    if(connection.QueryAsync("[RegionsSelectAll]", null,
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
