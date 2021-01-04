using CourseManagement.Data;
using CourseManagement.Models;
using CourseManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CourseManagement.Pages.Instructors
{
    /// <summary>
    /// PageModel for assigning Instructors to courses
    /// </summary>
    public class InstructorCoursesPageModel : PageModel
    {
        /// <summary>
        /// A list of courses to assign
        /// </summary>
        public List<AssignedCourseData> AssignedCourseDataList;

        /// <summary>
        /// Load the assigned courses for a student.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="instructor"></param>
        public void PopulateAssignedCourseData(UniversityContext context,
                                               Instructor instructor)
        {
            var allCourses = context.Courses;
            var instructorCourses = new HashSet<int>(
                instructor.InstructorCourseAssignments.Select(c => c.CourseID));
            AssignedCourseDataList = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                AssignedCourseDataList.Add(new AssignedCourseData
                {
                    CourseID = course.ID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.ID)
                });
            }
        }

        /// <summary>
        /// Method for updating the assigned courses of an instructor.
        /// It adds or removes courses, that are assigned to one instructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="selectedCourses"></param>
        /// <param name="instructorToUpdate"></param>
        public void UpdateInstructorCourses(UniversityContext context,
            string[] selectedCourses, Instructor instructorToUpdate)
        {
            if (selectedCourses == null)
            {
                instructorToUpdate.InstructorCourseAssignments = new List<InstructorCourseAssignment>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (instructorToUpdate.InstructorCourseAssignments.Select(c => c.Course.ID));
            foreach (var course in context.Courses)
            {
                if (selectedCoursesHS.Contains(course.ID.ToString()))
                {
                    if (!instructorCourses.Contains(course.ID))
                    {
                        instructorToUpdate.InstructorCourseAssignments.Add(
                            new InstructorCourseAssignment
                            {
                                InstructorID = instructorToUpdate.ID,
                                CourseID = course.ID
                            });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(course.ID))
                    {
                        InstructorCourseAssignment courseToRemove
                            = instructorToUpdate
                                .InstructorCourseAssignments
                                .SingleOrDefault(i => i.CourseID == course.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}