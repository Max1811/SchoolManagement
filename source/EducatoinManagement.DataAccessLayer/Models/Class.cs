using System;
using System.Collections.Generic;
using System.Text;

namespace EducatoinManagement.DataAccessLayer.Models
{
    public class Class
    {
        public int Id { get; set; }
        public int SchoolId { get; set; }
        public int ClassNumber { get; set; }
        public int ClassParalel { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
