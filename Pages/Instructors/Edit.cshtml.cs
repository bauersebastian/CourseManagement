using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Models;

namespace CourseManagement.Pages.Instructors
{
    public class EditModel : InstructorCoursesPageModel
    {
        private readonly CourseManagement.Data.UniversityContext _context;

        public EditModel(CourseManagement.Data.UniversityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Instructor Instructor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Load the instructor together with CourseAssignments and Courses
            Instructor = await _context.Instructors
                .Include(i => i.InstructorCourseAssignments)
                    .ThenInclude(i => i.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Instructor == null)
            {
                return NotFound();
            }

            // Load the assigned courses
            PopulateAssignedCourseData(_context, Instructor);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCourses)
        {
            if (id == null)
            {
                return NotFound();
            }
            // load the instructor with related data from the db
            var instructorToUpdate = await _context.Instructors
                .Include(i => i.InstructorCourseAssignments)
                    .ThenInclude(i => i.Course)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (instructorToUpdate == null)
            {
                return NotFound();
            }
            // if updates are necessary update the record in the db
            if (await TryUpdateModelAsync<Instructor>(
                instructorToUpdate,
                "Instructor",
                i => i.FirstName, i => i.LastName,
                i => i.Degree, i => i.Street,
                i => i.City, i => i.Birthdate,
                i => i.ZipCode))
            {
                UpdateInstructorCourses(_context, selectedCourses, instructorToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            // if TryUpdateModelAsync fails load the edit page again
            UpdateInstructorCourses(_context, selectedCourses, instructorToUpdate);
            PopulateAssignedCourseData(_context, instructorToUpdate);
            return Page();
        }
    }
}
