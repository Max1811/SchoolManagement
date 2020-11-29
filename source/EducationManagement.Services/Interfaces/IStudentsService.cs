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
        public Task<List<Student>> GetAllStudentsAsync();

        public Task<Student> Get(int id);

        public Task<IActionResult> GenerateRandomData(int minStudentsCount, int maxStudentsCount);

        public Task DeleteStudentById(int id);

        public Task InsertStudent(string firstName, string lastName, string patronymic, int age, int classId);
    }
}
