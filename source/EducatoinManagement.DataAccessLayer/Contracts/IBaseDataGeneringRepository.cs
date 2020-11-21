using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Contracts
{
    public interface IBaseDataGeneringRepository
    {
        public Task<IActionResult> GenerateDataAsync(string generateDataProcedure, string checkIsDataGeneratedProcedure, object parameters);
    }
}
