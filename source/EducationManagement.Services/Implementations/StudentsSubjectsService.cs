using EducationManagement.Services.Interfaces;
using EducatoinManagement.DataAccessLayer.Contracts;
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

        public async Task<IActionResult> GenerateRandomData(int subjectsPerStudent)
        {
            return await studentsSubjectsRespository.GeneratePrimaryData(subjectsPerStudent);
        }
    }
}
