using System;
using CourseManagement.Data;
using CourseManagement.Models;
using CourseManagement.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace CourseManagement.Pages.Students
{
    /// <summary>
    /// PageModel for assigning Students to courses
    /// </summary>
    public class StudentCoursesPageModel : PageModel
    {
        /// <summary>
        /// A list of courses to assign
        /// </summary>
        public List<AssignedCourseData> AssignedCourseDataList;

        /// <summary>
        /// Load the assigned courses for a student.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="student"></param>
        public void PopulateAssignedCourseData(UniversityContext context,
                                               Student student)
        {
            var allCourses = context.Courses;
            var studentCourses = new HashSet<int>(
                student.Enrollments.Select(c => c.CourseID));
            AssignedCourseDataList = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                AssignedCourseDataList.Add(new AssignedCourseData
                {
                    CourseID = course.ID,
                    Title = course.Title,
                    Term = (TermType)course.Term,
                    Assigned = studentCourses.Contains(course.ID)
                });
            }
        }

        /// <summary>
        /// Method for updating the assigned courses of an instructor.
        /// It adds or removes courses, that are assigned to one instructor.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="selectedCourses"></param>
        /// <param name="studentToUpdate"></param>
        public void UpdateStudentCourses(UniversityContext context,
            string[] selectedCourses, Student studentToUpdate)
        {
            if (selectedCourses == null)
            {
                studentToUpdate.Enrollments = new List<Enrollment>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var studentCourses = new HashSet<int>
                (studentToUpdate.Enrollments.Select(c => c.Course.ID));
            foreach (var course in context.Courses)
            {
                if (selectedCoursesHS.Contains(course.ID.ToString()))
                {
                    if (!studentCourses.Contains(course.ID))
                    {
                        studentToUpdate.Enrollments.Add(
                            new Enrollment
                            {
                                StudentID = studentToUpdate.ID,
                                CourseID = course.ID
                            });
                    }
                }
                else
                {
                    if (studentCourses.Contains(course.ID))
                    {
                        Enrollment courseToRemove
                            = studentToUpdate
                                .Enrollments
                                .SingleOrDefault(i => i.CourseID == course.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}