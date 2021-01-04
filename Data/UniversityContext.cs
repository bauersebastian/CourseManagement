using Microsoft.EntityFrameworkCore;
using CourseManagement.Models;

namespace CourseManagement.Data
{
    /// <summary>
    /// DBContext maps to the MS SQL Database that has a schema that the DBContext understands.
    /// </summary>
    public class UniversityContext : DbContext
    {
        /// <summary>
        /// Context for the interaction with the db.
        /// </summary>
        /// <param name="options"></param>
        public UniversityContext (DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Students - based on the abstract person class.
        /// </summary>
        public DbSet<Student> Students { get; set; }

        /// <summary>
        /// Instructors - based on the abstract person class
        /// + an information about the degree of an instructor
        /// </summary>
        public DbSet<Instructor> Instructors { get; set; }

        /// <summary>
        /// The enrollment property saves the relationship between students and courses. 
        /// </summary>
        public DbSet<Enrollment> Enrollments { get; set; }

        /// <summary>
        /// Basic information about a course held in the university.
        /// </summary>
        public DbSet<Course> Courses { get; set; }

        /// <summary>
        /// The InstructorCourseAssignment property saves the relationship between instructors and courses.
        /// </summary>
        public DbSet<InstructorCourseAssignment> InstructorCourseAssignments { get; set; }
        /// <summary>
        /// Create the tables for courses, enrollments, students, instructors and InstructorCourseAssignments.
        /// The InstructorCourseAssignments consists of the keys CourseID and InstructorID only.
        /// The same logic could have been applied to enrollments - for demo/test purpopes the enrollment has an own EnrollmentID.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<InstructorCourseAssignment>().ToTable("InstructorCourseAssignment");

            modelBuilder.Entity<InstructorCourseAssignment>()
                .HasKey(c => new { c.CourseID, c.InstructorID });
        }
    }
}
