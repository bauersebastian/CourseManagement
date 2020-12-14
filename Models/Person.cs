using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseManagement.Models
{
    public class Person
    {
        public int ID { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public String Street { get; set; }
        // use String for ZipCode, as in international context the ZIP Code can contain letters
        public String ZipCode { get; set; }
        public String City { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
