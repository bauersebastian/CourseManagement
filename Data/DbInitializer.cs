using CourseManagement.Data;
using CourseManagement.Models;
using System;
using System.Linq;

namespace CourseManagement.Data
{
    public static class DbInitializer
    {
        public static void Initialize(UniversityContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student{FirstName="Carson",LastName="Alexander",Birthdate=DateTime.Parse("2019-09-01")},
                new Student{FirstName="Meredith",LastName="Alonso",Birthdate=DateTime.Parse("2017-09-01")},
                new Student{FirstName="Arturo",LastName="Anand",Birthdate=DateTime.Parse("2018-09-01")},
                new Student{FirstName="Gytis",LastName="Barzdukas",Birthdate=DateTime.Parse("2017-09-01")},
                new Student{FirstName="Yan",LastName="Li",Birthdate=DateTime.Parse("2017-09-01")},
                new Student{FirstName="Peggy",LastName="Justice",Birthdate=DateTime.Parse("2016-09-01")},
                new Student{FirstName="Laura",LastName="Norman",Birthdate=DateTime.Parse("2018-09-01")},
                new Student{FirstName="Nino",LastName="Olivetto",Birthdate=DateTime.Parse("2019-09-01")}
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{CourseID=1050,Title="Chemistry"},
                new Course{CourseID=4022,Title="Microeconomics"},
                new Course{CourseID=4041,Title="Macroeconomics"},
                new Course{CourseID=1045,Title="Calculus"},
                new Course{CourseID=3141,Title="Trigonometry"},
                new Course{CourseID=2021,Title="Composition"},
                new Course{CourseID=2042,Title="Literature"}
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();

            var enrollments = new Enrollment[]
            {
                new Enrollment{StudentID=1,CourseID=1050},
                new Enrollment{StudentID=1,CourseID=4022},
                new Enrollment{StudentID=1,CourseID=4041},
                new Enrollment{StudentID=2,CourseID=1045},
                new Enrollment{StudentID=2,CourseID=3141},
                new Enrollment{StudentID=2,CourseID=2021},
                new Enrollment{StudentID=3,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=1050},
                new Enrollment{StudentID=4,CourseID=4022},
                new Enrollment{StudentID=5,CourseID=4041},
                new Enrollment{StudentID=6,CourseID=1045},
                new Enrollment{StudentID=7,CourseID=3141},
            };

            context.Enrollments.AddRange(enrollments);
            context.SaveChanges();
        }
    }
}