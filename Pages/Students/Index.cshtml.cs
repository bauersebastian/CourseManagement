using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Data;
using CourseManagement.Models;

namespace CourseManagement.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly CourseManagement.Data.UniversityContext _context;

        public IndexModel(CourseManagement.Data.UniversityContext context)
        {
            _context = context;
        }

        /// <summary>
        /// NameSort specifies the type of sorting for names.
        /// </summary>
        public string NameSort { get; set; }

        /// <summary>
        /// DateSort specifies the type of sorting per Birthdate.
        /// </summary>
        public string DateSort { get; set; }

        /// <summary>
        /// Stores the current set filter.
        /// </summary>
        public string CurrentFilter { get; set; }

        /// <summary>
        /// Stores the current set sorting.
        /// </summary>
        public string CurrentSort { get; set; }

        /// <summary>
        /// List of Students.
        /// </summary>
        public IList<Student> Students { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            CurrentFilter = searchString;

            IQueryable<Student> studentsIQ = from s in _context.Students
                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                studentsIQ = studentsIQ.Where(s => s.LastName.Contains(searchString)
                || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.Birthdate);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.Birthdate);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                    break;
            }

            Students = await studentsIQ.AsNoTracking().ToListAsync();
        }
    }
}
