using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Contracts
{
    public interface IStudentsRepository
    {
        public Task<List<Student>> GetStudents(CancellationToken token = default);
        public Task<IActionResult> GeneratePrimaryData(int minStudentsCount, int maxStudentsCount);
        public Task<Student> GetStudentById(int id);
        public Task DeleteStudentById(int id);
    }
}
