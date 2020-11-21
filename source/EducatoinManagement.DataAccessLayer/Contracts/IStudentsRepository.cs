using EducatoinManagement.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace EducatoinManagement.DataAccessLayer.Contracts
{
    public interface IStudentsRepository
    {
        public List<Student> GetStudents(CancellationToken token = default);
    }
}
