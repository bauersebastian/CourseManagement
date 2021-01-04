using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseManagement.Data;
using CourseManagement.Models;

namespace CourseManagement.Pages.Students
{
    public class CreateModel : StudentCoursesPageModel
    {
        private readonly CourseManagement.Data.UniversityContext _context;

        public CreateModel(CourseManagement.Data.UniversityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var student = new Student();
            student.Enrollments = new List<Enrollment>();
            PopulateAssignedCourseData(_context, student);
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            var newStudent = new Student();
            if (selectedCourses != null)
            {
                newStudent.Enrollments = new List<Enrollment>();
                foreach (var course in selectedCourses)
                {
                    var courseToAdd = new Enrollment
                    {
                        CourseID = int.Parse(course)
                    };
                    newStudent.Enrollments.Add(courseToAdd);
                }
            }

            if (await TryUpdateModelAsync<Student>(
                newStudent,
                "student",   // Prefix for form value.
                s => s.FirstName, 
                s => s.LastName, 
                s => s.Birthdate,
                s => s.Street,
                s => s.ZipCode,
                s => s.City))
            {
                _context.Students.Add(newStudent);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCourseData(_context, newStudent);
            return Page();
        }
    }
}
