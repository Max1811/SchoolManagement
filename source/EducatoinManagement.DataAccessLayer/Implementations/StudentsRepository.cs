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
    public class StudentsRepository : IStudentsRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;

        public StudentsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
        }

        public async Task DeleteStudentById(int id)
        {
            var procedure = "[DeleteStudentById]";
            var values = new
            {
                Id = id
            };

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.QueryAsync<Student>(procedure, values, commandType: CommandType.StoredProcedure);
            }
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
            var procedure = "[GetStudentById]";
            var values = new
            {
                Id = id
            };

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Student>(procedure, values, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        public async Task<List<Student>> GetStudents(CancellationToken cancellationToken = default)
        {
            var procedure = "[StudentsSelectAll]";

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Student>(procedure, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }


    }
}
