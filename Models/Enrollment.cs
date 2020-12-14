using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public int InstructorID { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
        public Instructor Instructor { get; set; }
    }
}
