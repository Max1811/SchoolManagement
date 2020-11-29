using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Interfaces
{
    public interface IStudentsSubjectsService
    {
        public Task<IActionResult> GenerateRandomData(int subjectsPerStudent);
        public Task<StudentSubject> Get(int id);
        Task Delete(int id);
    }
}
