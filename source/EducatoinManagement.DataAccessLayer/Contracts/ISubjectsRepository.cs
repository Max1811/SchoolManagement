using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Contracts
{
    public interface ISubjectsRepository
    {
        public Task<IActionResult> GeneratePrimaryData(int subjectsCount);
        public Task<Subject> Get(int id);
        Task Delete(int id);
        Task<IEnumerable<Subject>> GetAllAsync();
    }
}
