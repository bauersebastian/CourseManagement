using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Models.ViewModels
{
    /// <summary>
    /// The InstructorIndexData saves temporary data for related data.
    /// </summary>
    public class InstructorIndexData
    {
        /// <summary>
        /// List of courses
        /// </summary>
        public IEnumerable<Course> Courses { get; set; }
        /// <summary>
        /// List of instructors
        /// </summary>
        public IEnumerable<Instructor> Instructors { get; set; }
        /// <summary>
        /// List of enrollments to a course.
        /// </summary>
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
