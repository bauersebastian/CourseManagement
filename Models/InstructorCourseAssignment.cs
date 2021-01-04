namespace CourseManagement.Models
{
    /// <summary>
    /// This class represents the relationship of a instructor to a course.
    /// A course can have multiple instructors.
    /// A instructor can be assigned to multiple courses.
    /// </summary>
    public class InstructorCourseAssignment
    {
        /// <summary>
        /// The ID of the instructor.
        /// </summary>
        public int InstructorID { get; set; }
        /// <summary>
        /// The ID of the course.
        /// </summary>
        public int CourseID { get; set; }
        /// <summary>
        /// The data of the related instructor
        /// </summary>
        public Instructor Instructor { get; set; }
        /// <summary>
        /// The data of the related course.
        /// </summary>
        public Course Course { get; set; }
    }
}
