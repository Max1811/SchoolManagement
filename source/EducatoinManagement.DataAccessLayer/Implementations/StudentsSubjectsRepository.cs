using EducatoinManagement.DataAccessLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Implementations
{
    public class StudentsSubjectsRepository : IStudentsSubjectsRespository
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;
        public StudentsSubjectsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
        }

        public async Task<IActionResult> GeneratePrimaryData(int subjectsPerStudentCount)
        {
            var procedure = "[GenerateRandomStudentsSubjects]";
            var values = new
            {
                SubjectsPerStudent = subjectsPerStudentCount
            };

            return await baseDataGeneringRepository.GenerateDataAsync(procedure, "[StudentsSubjectsSelectAny]", values);
        }
    }
}
