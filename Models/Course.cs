using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Models
{
    /// <summary>
    /// The possible selection of Terms is based on this enum.
    /// The user selects one term upon creation of courses.
    /// </summary>
    public enum TermType
    {
        [Display(Name = "Wintersemester 2020/21")]
        WS_2020_21,
        [Display(Name = "Sommersemester 2021")]
        SS_2021,
        [Display(Name = "Wintersemester 2021 / 22")]
        WS_2021_22,
        [Display(Name = "Sommersemster 2022")]
        SS_2022,
        [Display(Name = "Wintersemester 2022/23")]
        WS_2022_23,
        [Display(Name = "Sommersemester 2023")]
        SS_2023,
        [Display(Name = "Wintersemester 2023/24")]
        WS_2023_24,
        [Display(Name = "Sommersemester 2024")]
        SS_2024
    }

    /// <summary>
    /// The base model for Courses.
    /// </summary>
    public class Course
    {
        /// <summary>
        /// ID field is the primary key for courses.
        /// </summary>
        [Display(Name = "Kursnummer")]
        public int ID { get; set; }

        /// <summary>
        /// Title of the course.
        /// </summary>
        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Titel")]
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// A description of the course.
        /// Minimum of 5 characters. Max. 1024 characters.
        /// </summary>
        [Display(Name = "Beschreibung")]
        [Required]
        [MinLength(5)]
        [MaxLength(1024)]
        public string Description { get; set; }

        /// <summary>
        /// The term in which the course takes place.
        /// Dropdown list of limited choices, based on the enum TermType.
        /// </summary>
        [Display(Name = "Semester")]
        [EnumDataType(typeof(TermType))]
        public TermType? Term { get; set; }

        /// <summary>
        /// The date on which the course starts.
        /// </summary>
        [Display(Name = "Startdatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// The date on which the course ends.
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [Display(Name = "Enddatum")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Collection of enrollments.
        /// This collection saves the relation of courses to students.
        /// </summary>
        public ICollection<Enrollment> Enrollments { get; set; }

        /// <summary>
        /// Collection of InstrucorCourseAssignments.
        /// This collection saves the relation of courses to instructors.
        /// </summary>
        public ICollection<InstructorCourseAssignment> InstructorCourseAssignments { get; set; }

    }
}
