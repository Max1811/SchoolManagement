using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Contracts
{
    public interface IStudentsSubjectsRespository
    {
        public Task<IActionResult> GeneratePrimaryData(int subjectsPerStudent);
        public Task<StudentSubject> Get(int id);
        Task Delete(int id);
    }
}
