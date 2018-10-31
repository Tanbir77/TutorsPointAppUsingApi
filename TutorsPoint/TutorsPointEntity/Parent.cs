using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorsPointEntity
{
    public  class Parent
    {   
        public int ParentId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public String ParentName { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public String Gender { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Phone is required")]
        public String Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public String Address { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public String Password { get; set; }

    }
}
