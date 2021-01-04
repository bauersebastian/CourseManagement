using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Models;

namespace CourseManagement.Pages.Students
{
    public class EditModel : StudentCoursesPageModel
    {
        private readonly CourseManagement.Data.UniversityContext _context;

        public EditModel(CourseManagement.Data.UniversityContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Load the student together with Enrollments and Courses
            Student = await _context.Students
                .Include(i => i.Enrollments)
                    .ThenInclude(i => i.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Student == null)
            {
                return NotFound();
            }
            PopulateAssignedCourseData(_context, Student);
            return Page();
        }

        /// <summary>
        /// OnPost Method takes care of updates to the Student.
        /// </summary>
        /// <param name="id">ID of the instructor</param>
        /// <returns></returns>
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCourses)
        {
            // if no ID is passed, we return a 404 page
            if(id == null)
            {
                return NotFound();
            }

            var studentToUpdate = await _context.Students
                .Include(i => i.Enrollments)
                    .ThenInclude(i => i.Course)
                .FirstOrDefaultAsync(s => s.ID == id);

            if(studentToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Student>(
                studentToUpdate,
                "Student",
                i => i.FirstName, i => i.LastName,
                i => i.Street,
                i => i.City, i => i.Birthdate,
                i => i.ZipCode))
            {
                UpdateStudentCourses(_context, selectedCourses, studentToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateStudentCourses(_context, selectedCourses, studentToUpdate);
            PopulateAssignedCourseData(_context, studentToUpdate);
            return Page();
        }

    }
}
