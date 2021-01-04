using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CourseManagement.Data;
using CourseManagement.Models;

namespace CourseManagement.Pages.Instructors
{
    public class CreateModel : InstructorCoursesPageModel
    {
        private readonly CourseManagement.Data.UniversityContext _context;

        public CreateModel(CourseManagement.Data.UniversityContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var instructor = new Instructor();
            instructor.InstructorCourseAssignments = new List<InstructorCourseAssignment>();
            PopulateAssignedCourseData(_context, instructor);
            return Page();
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

        
        public async Task<IActionResult> OnPostAsync(string[] selectedCourses)
        {
            var newInstructor = new Instructor();
            if (selectedCourses != null)
            {
                newInstructor.InstructorCourseAssignments = new List<InstructorCourseAssignment>();
                foreach (var course in selectedCourses)
                {
                    var courseToAdd = new InstructorCourseAssignment
                    {
                        CourseID = int.Parse(course)
                    };
                    newInstructor.InstructorCourseAssignments.Add(courseToAdd);
                }
            }

            if(await TryUpdateModelAsync<Instructor>(
                newInstructor,
                "Instructor",
                i => i.FirstName, i => i.LastName,
                i => i.Degree, i => i.Street,
                i => i.City, i => i.Birthdate,
                i => i.ZipCode))
            {
                _context.Instructors.Add(newInstructor);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCourseData(_context, newInstructor);
            return Page();
        }
    }
}
