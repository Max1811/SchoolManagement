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

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await studentsRepository.GetStudents();
        }

        public async Task<Student> Get(int id)
        {
            return await studentsRepository.GetStudentById(id);
        }

        public async Task InsertStudent(string firstName, string lastName, string patronymic, int age, int classId)
        {
            Student student = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Patronymic = patronymic,
                Age = age,
                ClassId = classId
            };

            await studentsRepository.InsertStudentAsync(student);
        }
    }
}
