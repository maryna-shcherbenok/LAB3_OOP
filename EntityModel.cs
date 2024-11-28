using System;

namespace JSONDispatcher.Models
{
    public class EntityModel
    {
        public string FullName { get; set; }
        public string Faculty { get; set; } 
        public string Department { get; set; } 
        public string Specialty { get; set; } 
        public DateTime EnrollmentDate { get; set; } 
        public DateTime GraduationDate { get; set; }
        public string WorkHistory { get; set; }

        public override string ToString()
        {
            return $"{FullName}, {Faculty}, {Specialty}";
        }
    }
}
