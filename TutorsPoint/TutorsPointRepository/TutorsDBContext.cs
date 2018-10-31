using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorsPointEntity;

namespace TutorsPointRepository
{
    public class TutorsDBContext : DbContext
    {
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<Parent> Parents { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<ApplyInfo> ApplyInfoes { get; set; }



    }
}
