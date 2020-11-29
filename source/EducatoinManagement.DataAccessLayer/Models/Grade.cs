using System;
using System.Collections.Generic;
using System.Text;

namespace EducatoinManagement.DataAccessLayer.Models
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentsSubjectId { get; set; }
        public int GradeValue { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
