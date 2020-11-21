using EducationManagement.Services.Interfaces;
using EducatoinManagement.DataAccessLayer.Contracts;
using EducatoinManagement.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EducationManagement.Services.Implementations
{
    public class StudentsService : IStudentsService
    {
        private readonly IStudentsRepository studentsRepository;
        public StudentsService(IStudentsRepository studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        public List<Student> GetAllStudents(CancellationToken cancellationToken = default)
        {
            return studentsRepository.GetStudents(cancellationToken);
        }
    }
}
