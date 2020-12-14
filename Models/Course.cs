using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace CourseManagement.Models
{
    public enum Term
    {
        WS_2020_21,
        SS_2021,
        WS_2021_22,
        SS_2022,
        WS_2022_23,
        SS_2023,
        WS_2023_24,
        SS_2024
    }
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Term? Term { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}
