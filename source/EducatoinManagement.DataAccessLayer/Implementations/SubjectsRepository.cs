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
    public class SubjectsRepository : GenericCrudRepository<Subject>, ISubjectsRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;
        public SubjectsRepository(IConfiguration configuration)
            :base(configuration)
        {
            _configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
        }

        public async Task<Subject> Get(int id)
        {
            return await Get(id, "Regions");
        }

        public async Task Delete(int id)
        {
            await Delete(id, "Subjects");
        }

        public async Task<IActionResult> GeneratePrimaryData(int subjectsCount)
        {
            var procedure = "[GenerateRandomSubjects]";
            var values = new
            {
                SubjectsCount = subjectsCount
            };

            return await baseDataGeneringRepository.GenerateDataAsync(procedure, "[SubjectsSelectAny]", values);
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await GetAll("Subjects");
        }
    }
}
