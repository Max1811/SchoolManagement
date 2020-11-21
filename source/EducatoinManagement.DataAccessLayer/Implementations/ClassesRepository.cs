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
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Implementations
{
    public class ClassesRepository : IClassesRepository
    {
        private readonly IConfiguration configuration;
        public ClassesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IActionResult> GeneratePrimaryData(int maxAmountOfParalelClasses)
        {
            var procedure = "[GenerateRandomClasses]";
            var values = new
            {
                UpperParalelAmount = maxAmountOfParalelClasses
            };
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    if (connection.QueryAsync("[ClassesSelectAny]", null,
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
