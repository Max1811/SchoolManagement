using EducationManagement.Services.Interfaces;
using EducatoinManagement.DataAccessLayer.Contracts;
using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Implementations
{
    public class StudentsSubjectsService : IStudentsSubjectsService
    {
        private readonly IStudentsSubjectsRespository studentsSubjectsRespository;
        public StudentsSubjectsService(IStudentsSubjectsRespository studentsSubjectsRespository)
        {
            this.studentsSubjectsRespository = studentsSubjectsRespository;
        }

        public async Task Delete(int id)
        {
            await studentsSubjectsRespository.Delete(id);
        }

        public async Task<IActionResult> GenerateRandomData(int subjectsPerStudent)
        {
            return await studentsSubjectsRespository.GeneratePrimaryData(subjectsPerStudent);
        }

        public async Task<StudentSubject> Get(int id)
        {
            return await studentsSubjectsRespository.Get(id);
        }
    }
}
