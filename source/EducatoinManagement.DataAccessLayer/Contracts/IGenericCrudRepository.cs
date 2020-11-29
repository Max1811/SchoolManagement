using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Contracts
{
    public interface IGenericCrudRepository<T>
    {
        public Task Delete(int id, string tableName);
        public Task<T> Get(int id, string tableName);
        public Task<List<T>> GetAll(string tableName);
    }
}
