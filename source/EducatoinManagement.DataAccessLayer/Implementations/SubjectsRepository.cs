using EducatoinManagement.DataAccessLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Implementations
{
    public class SubjectsRepository : ISubjectsRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;
        public SubjectsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
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
    }
}
