using System.Collections.Generic;

namespace CourseManagement.Models
{
    /// <summary>
    /// This class represents a student.
    /// It is based on the abtract class Person.
    /// </summary>
    public class Student : Person
    {

        /// <summary>
        /// A collection of enrollments.
        /// This collection saves the relation between students and courses.
        /// </summary>
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
