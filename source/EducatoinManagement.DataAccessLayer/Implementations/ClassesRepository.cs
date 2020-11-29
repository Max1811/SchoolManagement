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
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Implementations
{
    public class ClassesRepository : GenericCrudRepository<Class>, IClassesRepository
    {
        private readonly IConfiguration configuration;

        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;

        public ClassesRepository(IConfiguration configuration)
            :base(configuration)
        {
            this.configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
        }

        public async Task Delete(int id)
        {
            await Delete(id, "Classes");
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

        public async Task<Class> Get(int id)
        {
            return await Get(id, "Classes");
        }
    }
}
