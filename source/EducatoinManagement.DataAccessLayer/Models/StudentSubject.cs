using System;
using System.Collections.Generic;
using System.Text;

namespace EducatoinManagement.DataAccessLayer.Models
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
