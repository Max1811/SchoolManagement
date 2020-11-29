using System;
using System.Collections.Generic;
using System.Text;

namespace EducatoinManagement.DataAccessLayer.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
