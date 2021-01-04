using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Data;
using CourseManagement.Models;

namespace CourseManagement.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly CourseManagement.Data.UniversityContext _context;

        public IndexModel(CourseManagement.Data.UniversityContext context)
        {
            _context = context;
        }

        public IList<Course> Courses { get;set; }

        public async Task OnGetAsync()
        {
            Courses = await _context.Courses.ToListAsync();
        }
    }
}
