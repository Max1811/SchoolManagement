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
    public class BaseDataGeneratingRepository : IBaseDataGeneringRepository
    {
        private readonly IConfiguration configuration;
        public BaseDataGeneratingRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IActionResult> GenerateDataAsync(string generateDataProcedure,
            string checkIsDataGeneratedProcedure,  object parameters)
        {
            StatusCodeResult returnStatusCodeResult;

            using (var dbconnection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    if (dbconnection.QueryAsync(checkIsDataGeneratedProcedure, null,
                        commandType: CommandType.StoredProcedure).Result.ToList().Count == 0)
                    {
                        await dbconnection.QueryAsync(generateDataProcedure, parameters, commandType: CommandType.StoredProcedure);
                        returnStatusCodeResult =  new StatusCodeResult(201);
                    }

                    returnStatusCodeResult = new StatusCodeResult(208);
                }
                catch (Exception ex)
                {
                    returnStatusCodeResult = new StatusCodeResult(400);
                }
            }

            return returnStatusCodeResult;
        }
    }
}
