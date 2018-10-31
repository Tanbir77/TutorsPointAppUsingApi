using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorsPointEntity
{
    public class Tutor
    {
        public int TutorId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string TutorName { get; set; }

        [Required(ErrorMessage = "BirthDate is required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public String Gender { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Institution is required")]
        public String Institution { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public String Password  { get; set; }





    }
}
