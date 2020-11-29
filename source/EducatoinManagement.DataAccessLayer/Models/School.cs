using System;
using System.Collections.Generic;
using System.Text;

namespace EducatoinManagement.DataAccessLayer.Models
{
    public class School
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public int SchoolNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
