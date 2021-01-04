using System.ComponentModel.DataAnnotations;
namespace CourseManagement.Models
{
    /// <summary>
    /// This class saves the relationship between courses and students.
    /// A course can have many students.
    /// A student can be enrolled in many courses.
    /// </summary>
    public class Enrollment
    {
        /// <summary>
        /// The primary key of the enrollment - ID.
        /// </summary>
        public int EnrollmentID { get; set; }

        /// <summary>
        /// The ID of the course, saved in this relationship.
        /// </summary>
        public int CourseID { get; set; }

        /// <summary>
        /// The ID of the student, saved in this relationship.
        /// </summary>
        public int StudentID { get; set; }

        /// <summary>
        /// The number of points the student achieved in the optional additional academic
        /// achievement (Studienleistung).
        /// </summary>
        [Display(Name = "Punkte Studienleistung")]
        [DisplayFormat(DataFormatString = "{0:n1}")]
        [Range(0.0, 18.0)]
        public double? PointsAcademicAchievement { get; set; }

        /// <summary>
        /// The number of points the student achieved in the exam.
        /// </summary>
        [Display(Name = "Punkte Klausur")]
        [DisplayFormat(DataFormatString = "{0:n1}")]
        [Range(1.0, 90.0)]
        public double? PointsExam { get; set; }
        /// <summary>
        /// The grade that the student achieved in the course.
        /// </summary>
        [Display(Name = "Note")]
        [DisplayFormat(DataFormatString = "{0:n1}")]
        [Range(1.0, 5.0)]
        public double? Grade { get; set; }

        /// <summary>
        /// Data of the related course.
        /// </summary>
        [Display(Name = "Modul")]
        public Course Course { get; set; }

        /// <summary>
        /// Data of the related student.
        /// </summary>
        [Display(Name = "Student")]
        public Student Student { get; set; }
    }
}
