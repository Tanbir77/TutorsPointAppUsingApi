using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorsPointEntity
{
    public class Post
    {   [Key]
        public int PostId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public String Title { get; set; }

        [Required(ErrorMessage = "Class is required")]
        public String  cls{ get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "This must be mentioned")]
        public  int DaysPerWeek{ get; set; }

        [Required(ErrorMessage = "Pereferable Salary is required")]
        public int Salary { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Preferable { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public String Gender { get; set; }

        [Required(ErrorMessage = "Medium is required")]
        public String Medium { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public String Sub{ get; set; }


        public String ParentEmail { get; set; }

        public int ParentId { get; set; }

    }
}
