using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Models.ViewModels
{
    /// <summary>
    /// Generic view model for storing assigned courses.
    /// </summary>
    public class AssignedCourseData
    {
        /// <summary>
        /// ID of the course
        /// </summary>
        public int CourseID { get; set; }
        /// <summary>
        /// Title of a course.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Assigned term to the course (e.g. Sommersemester 2021)
        /// </summary>
        public TermType Term { get; set; }
        /// <summary>
        /// Boolean value, is the course assigned or not?
        /// </summary>
        public bool Assigned { get; set; }
    }
}
