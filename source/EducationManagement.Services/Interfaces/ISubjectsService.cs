using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Interfaces
{
    public interface ISubjectsService
    {
        public Task<IActionResult> GenerateRandomData(int subjectsCount);
        Task<Subject> Get(int id);
        Task Delete(int id);
        Task<IEnumerable<Subject>> GetAllAsync();
    }
}
