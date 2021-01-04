using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CourseManagement.Models;
using CourseManagement.Models.ViewModels;

namespace CourseManagement.Pages.Instructors
{
    public class IndexModel : PageModel
    {
        private readonly CourseManagement.Data.UniversityContext _context;

        public IndexModel(CourseManagement.Data.UniversityContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }

        public InstructorIndexData InstructorData { get; set; }
        public int InstructorID { get; set; }
        public int CourseID { get; set; }

        public IList<Instructor> Instructors { get;set; }

        public async Task OnGetAsync(int? id, int? courseID, string sortOrder, string searchString)
        {
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CurrentFilter = searchString;

            IQueryable<Instructor> instructorIQ = from i in _context.Instructors
                                             select i;

            // if there is a search string, filter our list of instructors accordingly
            if (!String.IsNullOrEmpty(searchString))
            {
                instructorIQ = instructorIQ.Where(i => i.LastName.Contains(searchString)
                || i.FirstName.Contains(searchString));
            }

            // sort the data according to the specified sortOrder
            switch (sortOrder)
            {
                case "name_desc":
                    instructorIQ = instructorIQ.OrderByDescending(s => s.LastName);
                    break;
                default:
                    instructorIQ = instructorIQ.OrderBy(s => s.LastName);
                    break;
            }

            InstructorData = new InstructorIndexData();
            InstructorData.Instructors = await instructorIQ
                .Include(i => i.InstructorCourseAssignments)
                    .ThenInclude(i => i.Course)
                .ToListAsync();

            

            if (id != null)
            {
                InstructorID = id.Value;
                Instructor instructor = InstructorData.Instructors
                    .Where(i => i.ID == InstructorID).Single();
                InstructorData.Courses = instructor.InstructorCourseAssignments.Select(s => s.Course);
            }

            if (courseID != null)
            {
                CourseID = courseID.Value;
                var selectedCourse = InstructorData.Courses
                    .Where(x => x.ID == courseID).Single();
                await _context.Entry(selectedCourse).Collection(x => x.Enrollments).LoadAsync();
                foreach (Enrollment enrollment in selectedCourse.Enrollments)
                {
                    await _context.Entry(enrollment).Reference(x => x.Student).LoadAsync();
                }
                InstructorData.Enrollments = selectedCourse.Enrollments;

            }
        }
    }
}
