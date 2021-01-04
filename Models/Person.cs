using System;
using System.ComponentModel.DataAnnotations;

namespace CourseManagement.Models
{
    /// <summary>
    /// This is a abstract class that represent a person.
    /// It contains basic information about people, used in this app.
    /// </summary>
    abstract public class Person
    {
        /// <summary>
        /// ID of the person.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// First name of the person.
        /// Required information.
        /// </summary>
        [Display(Name = "Vorname")]
        [Required(ErrorMessage = "Eine Vorname wird benötigt.")]
        public String FirstName { get; set; }

        /// <summary>
        /// Last name of the person.
        /// Required information.
        /// </summary>
        [Display(Name = "Nachname")]
        [Required(ErrorMessage = "Bitte Nachname eingeben.")]
        public String LastName { get; set; }

        /// <summary>
        /// Birthdate of the person.
        /// Optional information.
        /// </summary>
        [Display(Name = "Geburtsdatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime Birthdate { get; set; }

        /// <summary>
        /// The street of the home address of the person.
        /// </summary>
        [Display(Name = "Straße")]
        public String Street { get; set; }

        /// <summary>
        /// ZipCode of the home address of the person.
        /// Use String for ZipCode, as in international context the ZIP Code can contain letters
        /// </summary>
        [Display(Name = "Postleitzahl")]
        [StringLength(10, ErrorMessage = "Die Postleitzahl kann nicht länger wie 10 Zeichen sein.")]
        public String ZipCode { get; set; }

        /// <summary>
        /// The place where the person lives.
        /// </summary>
        [Display(Name = "Ort")]
        public String City { get; set; }

        /// <summary>
        /// Property that returns the full name of the person.
        /// The full name consists of the first + the last name.
        /// </summary>
        [Display(Name = "Name")]
        public String FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
