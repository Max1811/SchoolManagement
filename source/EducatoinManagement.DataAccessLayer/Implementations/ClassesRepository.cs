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

        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;

        public ClassesRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
        }

        public async Task<IActionResult> GeneratePrimaryData(int maxAmountOfParalelClasses)
        {
            var procedure = "[GenerateRandomClasses]";
            var values = new
            {
                UpperParalelAmount = maxAmountOfParalelClasses
            };

            return await baseDataGeneringRepository.GenerateDataAsync(procedure, "[ClassesSelectAny]", values);
        }
    }
}
