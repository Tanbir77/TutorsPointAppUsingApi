using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TutorsPointEntity
{
    public class ApplyInfo
    {
        [Key]
        public int ApplyId { get; set; }
        public int PostId { get; set; }
        public String TutorEmail { get; set; }
  




    }
}
