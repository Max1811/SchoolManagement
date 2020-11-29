using System;
using System.Collections.Generic;
using System.Text;

namespace EducatoinManagement.DataAccessLayer.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public int YearOfStudying { get; set; }
        public int ClassId { get; set; }
        public int SchoolId { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; } = false;
    }
}
