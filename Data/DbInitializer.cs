using System;
using System.Collections.Generic;
using System.Linq;
using CourseManagement.Models;
using Faker;

namespace CourseManagement.Data
{
    /// <summary>
    /// The DdInitializer class.
    /// This class is intended for seeding the database during development.
    /// It seeds only the students, instructors and courses.
    /// The relationsships should be added manually later.
    /// </summary>
    public static class DbInitializer
    {
        /// <summary>
        /// The Initialize method seeds the database, if there are no students in the DB.
        /// It adds Students, Instructors and Courses.
        /// </summary>
        /// <param name="context"></param>
        public static void Initialize(UniversityContext context)
        {
            Random gen = new Random();
            DateTime RandomDay(DateTime start, DateTime end)
            {
                int range = (end - start).Days;
                return start.AddDays(gen.Next(range));
            }

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            int n = 0;

            List<Student> students = new List<Student>();
            do
            {
                Student student = new Student()
                {
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    Birthdate = RandomDay(new DateTime(1985, 1, 1), new DateTime(2002, 01, 01)),
                    Street = Faker.Address.StreetAddress(),
                    // we generate data for the German context with regards to zipcode starting at 10000
                    ZipCode = Faker.RandomNumber.Next(10000, 99999).ToString(),
                    City = Faker.Address.City()
                };
                students.Add(student);
                n++;
            } while (n <= 20);

            context.Students.AddRange(students);
            context.SaveChanges();
            n = 0;

            List<Instructor> instructors = new List<Instructor>();
            do
            {
                Instructor instructor = new Instructor()
                {
                    FirstName = Faker.Name.First(),
                    LastName = Faker.Name.Last(),
                    Birthdate = RandomDay(new DateTime(1965, 1, 1), new DateTime(1985, 01, 01)),
                    Street = Faker.Address.StreetAddress(),
                    // we generate data for the German context with regards to zipcode starting at 10000
                    ZipCode = Faker.RandomNumber.Next(10000, 99999).ToString(),
                    City = Faker.Address.City(),
                    Degree = "Prof. Dr."
                };
                instructors.Add(instructor);
                n++;
            } while (n <= 10);

            context.Instructors.AddRange(instructors);
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {
                    Title = "Software- und Qualitätsmanagement",
                    Description = "Softwareprojekte planen",
                    StartDate = DateTime.Parse("2021-10-01"),
                    EndDate = DateTime.Parse("2021-04-15"),
                    Term = TermType.WS_2021_22
                },
                new Course {
                    Title = "Softwareentwicklung Java",
                    Description = "Lerne Java",
                    StartDate = DateTime.Parse("2021-10-01"),
                    EndDate = DateTime.Parse("2021-04-15"),
                    Term = TermType.WS_2021_22
                },
                new Course {
                    Title = "Softwareentwicklung C#",
                    Description = "Lerne C#",
                    StartDate = DateTime.Parse("2021-10-01"),
                    EndDate = DateTime.Parse("2021-04-15"),
                    Term = TermType.WS_2021_22
                },
                new Course {
                    Title = "Digital Change Management",
                    Description = "Change Management durchführen",
                    StartDate = DateTime.Parse("2021-10-01"),
                    EndDate = DateTime.Parse("2021-04-15"),
                    Term = TermType.WS_2021_22
                },
                new Course {
                    Title = "Web Technologien",
                    Description = "Die Technologie hinter WWW verstehen.",
                    StartDate = DateTime.Parse("2021-10-01"),
                    EndDate = DateTime.Parse("2021-04-15"),
                    Term = TermType.WS_2021_22

                },
                new Course {
                    Title = "Enterprise Content Management",
                    Description = "ECM - Dokumente verwalten",
                    StartDate = DateTime.Parse("2021-10-01"),
                    EndDate = DateTime.Parse("2021-04-15"),
                    Term = TermType.WS_2021_22
                },
                new Course {
                    Title = "Data Science", 
                    Description = "Lerne R und Python für die Datenanalyse",
                    StartDate = DateTime.Parse("2021-10-01"),
                    EndDate = DateTime.Parse("2021-04-15"),
                    Term = TermType.WS_2021_22
                },
            };

            context.Courses.AddRange(courses);
            context.SaveChanges();
        }
    }
}