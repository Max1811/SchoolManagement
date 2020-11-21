using Dapper;
using EducatoinManagement.DataAccessLayer.Contracts;
using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;

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

        public List<Student> GetStudents(CancellationToken cancellationToken = default)
        {
            var sql = "SELECT * FROM Students";
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = connection.Query<Student>(sql, cancellationToken);
                return result.ToList();
            }
        }
    }
}
