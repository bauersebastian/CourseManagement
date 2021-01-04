using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Models
{
    /// <summary>
    /// This class represents a instructor.
    /// This class is based on the abstract class Person.
    /// </summary>
    public class Instructor : Person
    {
        /// <summary>
        /// Information about the degree of the instructor.
        /// </summary>
        [Display(Name = "Abschluss")]
        public String Degree { get; set; }

        /// <summary>
        /// Relationship of the instructor to courses.
        /// </summary>
        public ICollection<InstructorCourseAssignment> InstructorCourseAssignments { get; set; }

    }
}
