using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Data;
using CourseManagement.Models;

namespace CourseManagement.Pages.Instructors
{
    public class DeleteModel : PageModel
    {
        private readonly CourseManagement.Data.UniversityContext _context;

        public DeleteModel(CourseManagement.Data.UniversityContext context)
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

            Instructor = await _context.Instructors.FirstOrDefaultAsync(m => m.ID == id);

            if (Instructor == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Include InstructorCourseAssignments, so they get deleted as well
            Instructor = await _context.Instructors
                .Include(i => i.InstructorCourseAssignments)
                .SingleAsync(i => i.ID == id);

            if (Instructor != null)
            {
                _context.Instructors.Remove(Instructor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
