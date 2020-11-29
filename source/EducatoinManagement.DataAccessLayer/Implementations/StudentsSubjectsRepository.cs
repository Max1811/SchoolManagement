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
using System.Linq;

namespace EducatoinManagement.DataAccessLayer.Implementations
{
    public class StudentsSubjectsRepository : GenericCrudRepository<StudentSubject>, IStudentsSubjectsRespository
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;
        public StudentsSubjectsRepository(IConfiguration configuration)
            :base(configuration)
        {
            _configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
        }

        public async Task Delete(int id)
        {
            await Delete(id, "StudentsSubjects");
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

        public async Task<StudentSubject> Get(int id)
        {
            return await Get(id, "StudentsSubjects");
        }
    }
}   
