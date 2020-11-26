using EducationManagement.Services.Interfaces;
using EducatoinManagement.DataAccessLayer.Contracts;
using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EducationManagement.Services.Implementations
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository studentsRepository;
        public StudentsService(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public async Task DeleteStudentById(int id)
        {
            await studentsRepository.DeleteStudentById(id);
        }

        public async Task<IActionResult> GenerateRandomData(int minStudentsCount, int maxStudentsCount)
        {
            return await studentsRepository.GeneratePrimaryData(minStudentsCount, maxStudentsCount);
        }

        public async Task<List<Student>> GetAllStudents()
        {
            return await studentsRepository.GetStudents();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await studentsRepository.GetStudentById(id);
        }
    }
}
