using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EducationManagement.Services.Interfaces
{
    public interface IStudentsService
    {
        public Task<List<Student>> GetAllStudents();

        public Task<Student> GetStudentById(int id);

        public Task<IActionResult> GenerateRandomData(int minStudentsCount, int maxStudentsCount);

        public Task DeleteStudentById(int id);
    }
}
