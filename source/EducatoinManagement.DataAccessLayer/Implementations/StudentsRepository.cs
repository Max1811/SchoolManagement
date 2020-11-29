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
    public class StudentsRepository : GenericCrudRepository<Student>, IStudentsRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;

        public StudentsRepository(IConfiguration configuration)
            :base(configuration)
        {
            _configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
        }

        public async Task DeleteStudentById(int id)
        {
            await Delete(id, "Students");
        }

        public async Task<IActionResult> GeneratePrimaryData(int minStudentsCount, int maxStudentsCount)
        {
            var procedure = "[GenerateRandomStudents]";
            var values = new
            {
                LowerBound = minStudentsCount,
                UpperBound = maxStudentsCount
            };

            return await baseDataGeneringRepository.GenerateDataAsync(procedure, "[StudentsSelectAny]", values);
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await Get(id, "Students");
        }

        public async Task<List<Student>> GetStudents()
        {
            return await GetAll("Students");
        }

        public async Task InsertStudentAsync(Student student)
        {
            var procedure = "[InsertStudent]";
            var values = new
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Patronymic = student.Patronymic,
                Age = student.Age,
                ClassId = student.ClassId
            };

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.QueryAsync<Student>(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
