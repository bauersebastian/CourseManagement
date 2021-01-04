using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CourseManagement.Models;

namespace CourseManagement.Data
{
    /// <summary>
    /// The DdInitializer class.
    /// This class is intended for seeding the database during development.
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        /// The Initialize method seeds the database, if there are no students in the DB.
        /// It adds Students, Instructors, Courses and assigns Instructors to Courses, as well as Students to Courses.
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(UniversityContext context)
        {

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstName = "Sebastian",   LastName = "Müller",
                    Birthdate = DateTime.Parse("2000-09-01") },
                new Student { FirstName = "Merle", LastName = "Becker",
                    Birthdate = DateTime.Parse("1989-06-11") },
                new Student { FirstName = "Arthur",   LastName = "Schmidt",
                    Birthdate = DateTime.Parse("1995-09-21") },
                new Student { FirstName = "Roland",    LastName = "Roglic",
                    Birthdate = DateTime.Parse("1999-10-31") },
                new Student { FirstName = "Marius",      LastName = "Carthy",
                    Birthdate = DateTime.Parse("1988-09-05") },
                new Student { FirstName = "Steve",    LastName = "van Aart",
                    Birthdate = DateTime.Parse("1993-09-09") },
                new Student { FirstName = "Laura",    LastName = "Odenthal",
                    Birthdate = DateTime.Parse("1998-01-25") },
                new Student { FirstName = "Nino",     LastName = "Bianchi",
                    Birthdate = DateTime.Parse("2001-06-26") }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var instructors = new Instructor[]
            {
                new Instructor { FirstName = "Lucas",     LastName = "Vasquez",
                    Birthdate = DateTime.Parse("1975-03-05") },
                new Instructor { FirstName = "Sergio",    LastName = "Ramon",
                    Birthdate = DateTime.Parse("1980-07-06") },
                new Instructor { FirstName = "Flint",   LastName = "Stone",
                    Birthdate = DateTime.Parse("1965-08-01") },
                new Instructor { FirstName = "Donald", LastName = "Gates",
                    Birthdate = DateTime.Parse("1977-03-15") },
                new Instructor { FirstName = "Melinda",   LastName = "Schmerbauch",
                    Birthdate = DateTime.Parse("1968-02-12") }
            };

            context.Instructors.AddRange(instructors);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {Title = "Software- und Qualitätsmanagement",
                },
                new Course {Title = "Softwareentwicklung Java",
                },
                new Course {Title = "Softwareentwicklung C#",
                },
                new Course {Title = "Digital Change Management",
                },
                new Course {Title = "Web Technologien",
                },
                new Course {Title = "Enterprise Content Management",
                },
                new Course {Title = "Data Science", 
                },
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();


            var courseInstructors = new InstructorCourseAssignment[]
            {
                new InstructorCourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Software- und Qualitätsmanagement" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Vasquez").ID
                    },
                new InstructorCourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Software- und Qualitätsmanagement" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Ramon").ID
                    },
                new InstructorCourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Softwareentwicklung Java" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Stone").ID
                    },
                new InstructorCourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Softwareentwicklung C#" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Gates").ID
                    },
                new InstructorCourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Digital Change Management" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Schmerbauch").ID
                    },
                new InstructorCourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Web Technologien" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Stone").ID
                    },
                new InstructorCourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Enterprise Content Management" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Schmerbauch").ID
                    },
                new InstructorCourseAssignment {
                    CourseID = courses.Single(c => c.Title == "Data Science" ).ID,
                    InstructorID = instructors.Single(i => i.LastName == "Ramon").ID
                    },
            };

            context.InstructorCourseAssignments.AddRange(courseInstructors);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Bianchi").ID,
                    CourseID = courses.Single(c => c.Title == "Software- und Qualitätsmanagement" ).ID
                },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Odenthal").ID,
                    CourseID = courses.Single(c => c.Title == "Softwareentwicklung Java" ).ID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Müller").ID,
                    CourseID = courses.Single(c => c.Title == "Softwareentwicklung C#" ).ID
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Becker").ID,
                    CourseID = courses.Single(c => c.Title == "Digital Change Management" ).ID
                    },
                    new Enrollment {
                        StudentID = students.Single(s => s.LastName == "Becker").ID,
                    CourseID = courses.Single(c => c.Title == "Web Technologien" ).ID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Bianchi").ID,
                    CourseID = courses.Single(c => c.Title == "Enterprise Content Management" ).ID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Schmidt").ID,
                    CourseID = courses.Single(c => c.Title == "Software- und Qualitätsmanagement" ).ID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Roglic").ID,
                    CourseID = courses.Single(c => c.Title == "Softwareentwicklung Java").ID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Carthy").ID,
                    CourseID = courses.Single(c => c.Title == "Software- und Qualitätsmanagement").ID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Carthy").ID,
                    CourseID = courses.Single(c => c.Title == "Enterprise Content Management").ID
                    },
                    new Enrollment {
                    StudentID = students.Single(s => s.LastName == "Becker").ID,
                    CourseID = courses.Single(c => c.Title == "Data Science").ID
                    }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.ID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}