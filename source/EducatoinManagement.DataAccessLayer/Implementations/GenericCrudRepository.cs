using Dapper;
using EducatoinManagement.DataAccessLayer.Contracts;
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
    public class GenericCrudRepository<T> : IGenericCrudRepository<T>
    {
        private readonly IConfiguration _configuration;
        public GenericCrudRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task Delete(int id, string tableName)
        {
            var procedure = "[DeleteGeneric]";
            var values = new
            {
                TableName = tableName,
                ParamId = id
            };

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                await connection.QueryAsync<T>(procedure, values, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<T> Get(int id, string tableName)
        {
            var procedure = "[GetByIdGeneric]";
            var values = new
            {
                TableName = tableName,
                ParamId = id
            };

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<T>(procedure, values, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }

        public async Task<List<T>> GetAll(string tableName)
        {
            var procedure = "[GetAllGeneric]";
            var values = new
            {
                TableName = tableName
            };

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<T>(procedure, values, commandType: CommandType.StoredProcedure);
                return result.ToList();
            }
        }
    }
}
