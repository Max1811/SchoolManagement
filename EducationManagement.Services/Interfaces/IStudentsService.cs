using EducatoinManagement.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EducationManagement.Services.Interfaces
{
    public interface IStudentsService
    {
        public List<Student> GetAllStudents(CancellationToken cancellationToken = default);
    }
}
